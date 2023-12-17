using RiddleOfBlackStone.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Input;
using System.Xml;

namespace RiddleOfBlackStone.ViewModel
{
    public class OptionsPanelViewModel : INotifyPropertyChanged
    {

        private bool _music;
        private bool _displayTextLetterByLetter;
        private bool _firstInitilize = false;

        public ICommand ToggleMusicCommand { get; }
        public ICommand ToggleDisplayTextCommand { get; }

        public OptionsPanelViewModel()
        {
            LoadOptionsFromFile("options.xml");
            ToggleMusicCommand = new RelayCommand(p => ToggleMusic());
            ToggleDisplayTextCommand = new RelayCommand(p => ToggleText());
        }


        private void ToggleMusic()
        {
            //Music = !Music;
            SaveOptionsToFile("options.xml");
        }

        private void ToggleText()
        {
            //DisplayTextLetterByLetter = !DisplayTextLetterByLetter;
            SaveOptionsToFile("options.xml");
        }

        public bool Music
        {
            get { return _music; }
            set
            {
                if (_music != value)
                {
                    _music = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool DisplayTextLetterByLetter
        {
            get { return _displayTextLetterByLetter; }
            set
            {
                if (_displayTextLetterByLetter != value)
                {
                    _displayTextLetterByLetter = value;
                    OnPropertyChanged();
                }
            }
        }


        public void SaveOptionsToFile(string filename)
        {
            try
            {
                /*
                if (File.Exists(filename))
                {
                    LoadOptionsFromFile(filename);
                    return;
                }
                */
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

                //LoadOptionsFromFile(filename);
            }
            catch (Exception ex)
            {

                throw new Exception(filename, ex);
            }
        }

        private void LoadOptionsFromFile(string filename)
        {
            try
            {
                if (File.Exists(filename))
                {
                    XmlDocument optionsFile = new XmlDocument();
                    optionsFile.Load(filename);

                    XmlNode musicNode = optionsFile.SelectSingleNode("/Options/Music");
                    if (musicNode != null && bool.TryParse(musicNode.InnerText, out bool musicValue))
                    {
                        Music = musicValue;
                    }

                    XmlNode displayNode = optionsFile.SelectSingleNode("/Options/DisplayMode");
                    if (displayNode != null && bool.TryParse(displayNode.InnerText, out bool displayValue))
                    {
                        DisplayTextLetterByLetter = displayValue;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(filename, ex);
            }
        }

        public bool StopAndPlay()
        {
            LoadOptionsFromFile("options.xml");
            if (Music == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
