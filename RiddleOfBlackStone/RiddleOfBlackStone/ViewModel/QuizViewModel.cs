using ChooseYourAdventure.Model;
using RiddleOfBlackStone.Command;
using RiddleOfBlackStone.Model;
using RiddleOfBlackStone.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RiddleOfBlackStone
{
    public class QuizViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<QuestionViewModel> _questions;
        private int _currentQuestionIndex;
        private int _selectedOption;
        private Player _player;
        private Enemies _enemies;
        public QuizViewModel()
        {
            _player = new Player();
            _enemies = new Enemies();
            _questions = new ObservableCollection<QuestionViewModel>( 
                QuizInitializer.InitializeQuiz().Select(q => new QuestionViewModel(q)));
            _currentQuestionIndex = 0;
            ShowNextQuestionCommand = new RelayCommand(p => ShowQuestion());
        }

        public ObservableCollection<QuestionViewModel> Questions
        {
            get { return _questions; }
            set
            {
                if (_questions != value)
                {
                    _questions = value;
                    OnPropertyChanged(nameof(Questions));
                }
            }
        }

        public int CurrentQuestionIndex
        {
            get { return _currentQuestionIndex; }
            set
            {
                if (_currentQuestionIndex != value)
                {
                    _currentQuestionIndex = value;
                    OnPropertyChanged(nameof(CurrentQuestionIndex));
                    OnPropertyChanged(nameof(PlayerLives)); // Add this line to update PlayerLives
                    OnPropertyChanged(nameof(EnemyLives)); // Add this line to update EnemyLives
                    OnPropertyChanged(nameof(EnemyAttack));
                }
            }
        }
        public int PlayerLives
        {
            get { return _player.Lives; }
            set
            {
                if (_player.Lives != value)
                {
                    _player.Lives = value;
                    OnPropertyChanged(nameof(PlayerLives));
                }
            }
        }

        public int EnemyLives
        {
            get { return _enemies.live; }
            set
            {
                if (_enemies.live != value)
                {
                    _enemies.live = value;
                    OnPropertyChanged(nameof(EnemyLives));
                }
            }
        }

        public int EnemyAttack
        {
            get { return _enemies.attack; }
            set
            {
                if (_enemies.attack != value)
                {
                    _enemies.attack = value;
                    OnPropertyChanged(nameof(EnemyAttack));
                }
            }
        }
        public int SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                if (_selectedOption != value)
                {
                    _selectedOption = value;
                    OnPropertyChanged(nameof(SelectedOption));
                }
            }
        }
        
        public bool IsOption0Selected
        {
            get { return SelectedOption == 0; }
            set { if (value) SelectedOption = 0; }
        }

        public bool IsOption1Selected
        {
            get { return SelectedOption == 1; }
            set { if (value) SelectedOption = 1; }
        }

        public bool IsOption2Selected
        {
            get { return SelectedOption == 2; }
            set { if (value) SelectedOption = 2; }
        }

        public bool IsOption3Selected
        {
            get { return SelectedOption == 3; }
            set { if (value) SelectedOption = 3; }
        }

        public void ShowQuestion()
        {
            if (CurrentQuestionIndex < Questions.Count - 1)
            {
                CurrentQuestionIndex++;
                if (!Questions[CurrentQuestionIndex - 1].CorrectAnswer)
                {
                    _enemies.AttackPlayer(_player);
                }

                SelectedOption = -1;

                OnPropertyChanged(nameof(IsOption0Selected));
                OnPropertyChanged(nameof(IsOption1Selected));
                OnPropertyChanged(nameof(IsOption2Selected));
                OnPropertyChanged(nameof(IsOption3Selected));
                OnPropertyChanged(nameof(PlayerLives));
                OnPropertyChanged(nameof(EnemyLives));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ICommand ShowNextQuestionCommand { get; }

    }
}
