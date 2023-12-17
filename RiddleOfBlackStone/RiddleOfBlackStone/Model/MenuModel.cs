using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.Model
{
    public class MenuModel : IMenuModel
    {
        private bool _displaytextletterbyletter;
        private bool _music;
        private string _path;
        private bool _check;
        private SoundPlayer _soundPlayer;
        private AppState _appState;
        private bool _endOfGame;
        private int _userChoice;
        private bool _loaded;
        private string _loadGame;
        public MenuModel()
        {
            _soundPlayer = new SoundPlayer();
            _appState = new AppState();
            _endOfGame = false;
            _userChoice = 0;
            _music = false;
            _loaded = false;
            _loadGame = "Wczytaj grę";
        }
        public string LoadGame
        {
            get { return _loadGame; }
            set { _loadGame = value; }
        }
        public bool DisplayTextLetterByLetter
        {
            get { return _displaytextletterbyletter; }
            set { _displaytextletterbyletter = value; }
        }
        public bool Loaded
        {
            get { return _loaded; }
            set { _loaded = value; }
        }
        public bool Music
        {
            get { return _music; }
            set { _music = value; }
        }
        public bool Check
        {
            get { return _check; }
            set { _check = value; }
        }
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public SoundPlayer SoundPlayer
        {
            get { return _soundPlayer; }
            set { _soundPlayer = value; }
        }
        public AppState AppState
        {
            get { return _appState; }
            set { _appState = value; }
        }
        public bool EndOfGame
        {
            get { return _endOfGame; }
            set { _endOfGame = value; }
        }
        public int UserChoice
        {
            get { return _userChoice; }
            set { _userChoice = value; }
        }
    }
}
