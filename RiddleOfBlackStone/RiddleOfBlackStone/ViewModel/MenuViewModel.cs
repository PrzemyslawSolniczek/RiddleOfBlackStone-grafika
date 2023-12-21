using RiddleOfBlackStone.Command;
using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using YourNamespace;
using static System.Net.Mime.MediaTypeNames;

namespace RiddleOfBlackStone.ViewModel
{
    internal class MenuViewModel : INotifyPropertyChanged
    {
        private readonly IMenuModel _menuModel;
        private GameViewModel gameViewModel;

        

        public MenuViewModel(IMenuModel menuModel, MainWindow menuView)
        {
            gameViewModel = new GameViewModel(new GameModel(), menuView);
            _menuModel = menuModel;
        }

        public ICommand LoadCommand => new RelayCommand(p => Load(gameViewModel));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string LoadGame
        {
            get { return _menuModel.LoadGame; }
            set
            {
                if (_menuModel.LoadGame != value)
                {
                    _menuModel.LoadGame = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool DisplayTextLetterByLetter
        {
            get { return _menuModel.DisplayTextLetterByLetter; }
            set
            {
                if (_menuModel.DisplayTextLetterByLetter != value)
                {
                    _menuModel.DisplayTextLetterByLetter = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool Loaded
        {
            get { return _menuModel.Loaded; }
            set
            {
                if (_menuModel.Loaded != value)
                {
                    _menuModel.Loaded = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Music
        {
            get { return _menuModel.Music; }
            set
            {
                if (_menuModel.Music != value)
                {
                    _menuModel.Music = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Check
        {
            get { return _menuModel.Check; }
            set
            {
                if (_menuModel.Check != value)
                {
                    _menuModel.Check = value;
                    OnPropertyChanged();
                }
            }
        }

        public string PathToMusic
        {
            get { return _menuModel.Path; }
            set
            {
                if (_menuModel.Path != value)
                {
                    _menuModel.Path = value;
                    OnPropertyChanged();
                }
            }
        }
        public SoundPlayer SoundPlayer
        {
            get { return _menuModel.SoundPlayer; }
            set
            {
                if (_menuModel.SoundPlayer != value)
                {
                    _menuModel.SoundPlayer = value;
                    OnPropertyChanged();
                }
            }
        }
        public AppState AppState
        {
            get { return _menuModel.AppState; }
            set
            {
                if (_menuModel.AppState != value)
                {
                    _menuModel.AppState = value;
                    OnPropertyChanged();
                }
            }
        }
        public bool EndOfGame
        {
            get { return _menuModel.EndOfGame; }
            set
            {
                if (_menuModel.EndOfGame != value)
                {
                    _menuModel.EndOfGame = value;
                    OnPropertyChanged();
                }
            }
        }
        public int UserChoice
        {
            get { return _menuModel.UserChoice; }
            set
            {
                if (_menuModel.UserChoice != value)
                {
                    _menuModel.UserChoice = value;
                    OnPropertyChanged();
                }
            }
        }
        private int selectedOption;
        public int SelectedOption
        {
            get { return selectedOption; }
            set
            {
                selectedOption = value;
                OnPropertyChanged();
            }
        }

        public void SaveOptionsToFile(string filename)
        {
            try
            {
                XmlDocument optionsFile = new XmlDocument();
                XmlElement root = optionsFile.CreateElement("Options");
                optionsFile.AppendChild(root);

                XmlElement musicElement = optionsFile.CreateElement("Music");
                musicElement.InnerText = Music.ToString();
                root.AppendChild(musicElement);

                XmlElement displayLettersElement = optionsFile.CreateElement("DisplayMode");
                displayLettersElement.InnerText = DisplayTextLetterByLetter.ToString();
                root.AppendChild(displayLettersElement);

                optionsFile.Save(filename);
            } catch(Exception ex)
            {
                
                throw new Exception(filename, ex);
            }
        }

        public void Save(GameViewModel emp)
        {
            AppState appState = new AppState
            {
                Scene = emp.CurrentScene,
                Lives = emp.Player.Lives,
                sum = emp.Sum
            };
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(appState.GetType());
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            using (StreamWriter output = new StreamWriter(Path.Combine(docPath, "save.xml")))
            {
                x.Serialize(output, appState);
            }
        }
        public Scene Load(GameViewModel emp)
        {
            AppState appState = new AppState
            {
                Scene = emp.CurrentScene,
                Lives = emp.Player.Lives,
                sum = emp.Sum
            };
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(appState.GetType());
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(docPath, "save.xml");
            if (File.Exists(filePath))
            {
                using (StreamReader output = new StreamReader(filePath))
                {
                    var loadedScene = (AppState)x.Deserialize(output);
                    emp.CurrentScene = loadedScene.Scene;
                    emp.Player.Lives = loadedScene.Lives;
                    emp.Sum = loadedScene.sum;
                }
            }
            return emp.CurrentScene;
        }

    }
}
