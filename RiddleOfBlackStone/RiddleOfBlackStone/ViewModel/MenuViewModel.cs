using RiddleOfBlackStone.Command;
using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using static System.Net.Mime.MediaTypeNames;

namespace RiddleOfBlackStone.ViewModel
{
    internal class MenuViewModel : INotifyPropertyChanged
    {
        private readonly IMenuModel _menuModel;
        private readonly IGameModel _gameModel;
        private GameViewModel gameViewModel;


        public MenuViewModel(IMenuModel menuModel, IGameModel gameModel)
        {
            gameViewModel = new GameViewModel(new GameModel());
            _menuModel = menuModel;
            _gameModel = gameModel;
           // Enter = new RelayCommand(p => HandleEnter());
        }

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

        public string Path
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

        public void StartGame()
        {
            gameViewModel.CurrentScene = ScenesViewModel.InitializeStory();
        }

        private void StopGame()
        {
            //throw new NotImplementedException();
        }
        private void AboutAuthors()
        {

            //throw new NotImplementedException();
        }
        private void CloseGame() 
        { 

        }
        private void Options() 
        {
            switch (selectedOption)
            {
                case 0:
                    break;
                    case 1:
                        DisplayTextLetterByLetter = !DisplayTextLetterByLetter;
                        break;
                    case 2:
                        SaveOptionsToFile("options.xml");
                        return;
            }
        }

        private void HandleUpArrow()
        {
            selectedOption = Math.Max(0, selectedOption);
        }

        private void HandleDownArrow()
        {
            selectedOption = Math.Min(3, selectedOption + 1); //DO SPRAWDZENIA
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

        public void HandleUserChoice()
        {
            switch (UserChoice)
            {
                case 0:
                    StartGame();
                    break;
                case 1:
                    StopGame();
                    break;
                case 2:
                    AboutAuthors();
                    break;
                case 3:
                    Options();
                    break;
                case 4:
                    CloseGame(); //do implementacji
                    break;
            }
        }

    }
}
