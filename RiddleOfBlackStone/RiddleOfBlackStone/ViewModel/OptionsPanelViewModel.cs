using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace RiddleOfBlackStone.ViewModel
{
    public class OptionsPanelViewModel : INotifyPropertyChanged
    {

        private bool _music;
        private bool _displayTextLetterByLetter;

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
            }
            catch (Exception ex)
            {

                throw new Exception(filename, ex);
            }
        }
        


        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
