using RiddleOfBlackStone.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.Model
{
    public class GameModel : IGameModel
    {
        private Scene _currentScene;
        private List<Question> _quiz;
        private AppState _appState;
        private bool _isLoaded;
        private int _sum;
        private int _choiceIndex;
        private Enemies _skeleton;
        private Player _player;
        private Random _random;
        private int _r;
        private Enemies _dragon;
        public GameModel()
        {
            _currentScene = ScenesViewModel.InitializeStory();
            _skeleton = new Enemies
            {
                attack = 1,
                live = 1
            };
            _dragon = new Enemies
            {
                attack = 2,
                live = 3
            };
            _player = new Player
            {
                Lives = 3
            };
            //_quiz = QuizInitializer.InitializeQuiz();
            //_random = new Random();
            //_r = _random.Next(_quiz.Count);
            _appState = new AppState
            {
                Scene = _currentScene,
                Lives = _player.Lives
            };

        }

        public Scene currentScene
        {
            get { return _currentScene; }
            set { _currentScene = value; }
        }
        public List<Question> quiz
        {
            get { return _quiz; }
            set { _quiz = value; }
        }
        public AppState appState
        {
            get { return _appState; }
            set { _appState = value; }
        }
        public bool isLoaded
        {
            get { return _isLoaded; }
            set { _isLoaded = value; }
        }
        public int sum
        {
            get { return _sum; }
            set { _sum = value; }
        }
        public int choiceIndex
        {
            get { return _choiceIndex; }
            set { _choiceIndex = value; }
        }
        public Enemies skeleton
        {
            get { return _skeleton; }
            set { _skeleton = value; }
        }
        public Enemies dragon
        {
            get { return _dragon; }
            set { _dragon = value; }
        }
        public Player player
        {
            get { return _player; }
            set { _player = value; }
        }
        public int r { get { return _r; } set { _r = value; } }
    }
}
