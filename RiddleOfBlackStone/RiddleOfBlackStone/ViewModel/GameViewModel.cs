using RiddleOfBlackStone.Command;
using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace RiddleOfBlackStone.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private DispatcherTimer textDisplayTimer;
        private int currentTextLength;
        private readonly IGameModel gameModel;
        private OptionsPanelViewModel optionsPanelViewModel = new OptionsPanelViewModel();

        public GameViewModel(IGameModel gameModel)
        {
            this.gameModel = gameModel;
        }

        private ObservableCollection<string> _choices;

        public ObservableCollection<string> Choices
        {
            get { return _choices; }
            set
            {
                _choices = value;
                OnPropertyChanged(nameof(Choices));
            }
        }

        private BitmapImage _Source;
        public BitmapImage Source
        {
            get { return _Source; }
            set
            {
                _Source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        private RelayCommand _choiceSelectedCommand;
        public ICommand ChoiceSelectedCommand
        {
            get
            {
                if (_choiceSelectedCommand == null)
                {
                    _choiceSelectedCommand = new RelayCommand(
                        param => HandleChoiceSelected((int)param),
                        param => true
                    );
                }
                return _choiceSelectedCommand;
            }
        }
        public Scene CurrentScene
        {
            get { return gameModel.currentScene; }
            set
            {
                if (gameModel.currentScene != value)
                {
                    gameModel.currentScene = value;
                    OnPropertyChanged(nameof(CurrentScene));
                }
            }
        }

        public List<Question> Quiz
        {
            get { return gameModel.quiz; }
            set
            {
                if (gameModel.quiz != value)
                {
                    gameModel.quiz = value;
                    OnPropertyChanged(nameof(Quiz));
                }
            }
        }

        public AppState AppState
        {
            get { return gameModel.appState; }
            set
            {
                if (gameModel.appState != value)
                {
                    gameModel.appState = value;
                    OnPropertyChanged(nameof(AppState));
                }
            }
        }

        public bool IsLoaded
        {
            get { return gameModel.isLoaded; }
            set
            {
                if (gameModel.isLoaded != value)
                {
                    gameModel.isLoaded = value;
                    OnPropertyChanged(nameof(IsLoaded));
                }
            }
        }

        public int Sum
        {
            get { return gameModel.sum; }
            set
            {
                if (gameModel.sum != value)
                {
                    gameModel.sum = value;
                    OnPropertyChanged(nameof(Sum));
                }
            }
        }

        public int ChoiceIndex
        {
            get { return gameModel.choiceIndex; }
            set
            {
                if (gameModel.choiceIndex != value)
                {
                    gameModel.choiceIndex = value;
                    OnPropertyChanged(nameof(ChoiceIndex));
                }
            }
        }

        public Enemies Skeleton
        {
            get { return gameModel.skeleton; }
            set
            {
                if (gameModel.skeleton != value)
                {
                    gameModel.skeleton = value;
                    OnPropertyChanged(nameof(Skeleton));
                }
            }
        }

        public Enemies Dragon
        {
            get { return gameModel.dragon; }
            set
            {
                if (gameModel.dragon != value)
                {
                    gameModel.dragon = value;
                    OnPropertyChanged(nameof(Dragon));
                }
            }
        }
        private string _textDescription;
        public string TextDescription
        {
            get { return _textDescription; }
            set
            {
                _textDescription = value;
                OnPropertyChanged(nameof(TextDescription));
            }
        }

        public Player Player
        {
            get { return gameModel.player; }
            set
            {
                if (gameModel.player != value)
                {
                    gameModel.player = value;
                    OnPropertyChanged(nameof(Player));
                }
            }
        }

        public int R
        {
            get { return gameModel.r; }
            set
            {
                if (gameModel.r != value)
                {
                    gameModel.r = value;
                    OnPropertyChanged(nameof(R));
                }
            }
        }

        private int selectedChoiceIndex;
        public int SelectedChoiceIndex
        {
            get { return selectedChoiceIndex; }
            set
            {
                selectedChoiceIndex = value;
                OnPropertyChanged(nameof(SelectedChoiceIndex));
                OnPropertyChanged(nameof(DisplayedChoices));
            }
        }



        public void DisplayChoicesWithHighlight(int choiceIndex)
        {
            for (int i = 0; i < CurrentScene.Choices.Count; i++)
            {
                if (i == choiceIndex)  // jezeli to aktualnie wybrana opcja
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($">> {CurrentScene.Choices[i].Description}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine(CurrentScene.Choices[i].Description);
                }
            }
        }

        private void InitializeTimer()
        {
            textDisplayTimer = new DispatcherTimer();
            //Generalnie to 0.3 - 0.1 to optymalne wartości, bo jak się daję więcej, to views nie nadąża ze zmianami
            textDisplayTimer.Interval = TimeSpan.FromMilliseconds(0.3);
            textDisplayTimer.Tick += TextDisplayTimer_Tick;
        }

        private void StartTextDisplayTimer(string text)
        {
            currentTextLength = 0;
            textDisplayTimer.Stop();
            textDisplayTimer.Start();
        }

        private void TextDisplayTimer_Tick(object sender, EventArgs e)
        {
            int remainingCharacters = CurrentScene.Description.Length - currentTextLength;

            if (remainingCharacters > 0)
            {
                TextDescription = CurrentScene.Description.Substring(0, currentTextLength);
                ++currentTextLength;
            }
            else
            {
                textDisplayTimer.Stop(); 
            }
            
        }

        public void StartGame()
        {
            CurrentScene = ScenesViewModel.InitializeStory();
            optionsPanelViewModel.LoadOptionsFromFile("options.xml");
            string initialChoice = "czarnyKamien";
            string initialImagePath = $"pictures/{initialChoice}.png";
            Source = new BitmapImage(new Uri(initialImagePath, UriKind.Relative));
            if (optionsPanelViewModel.DisplayTextLetterByLetter)
            {
                InitializeTimer();
                StartTextDisplayTimer(CurrentScene.Description);
            }
            else
            {
                TextDescription = CurrentScene.Description;
            }

            OnPropertyChanged(nameof(Source));
        }
        public void HandleChoiceSelected(int choiceIndex)
        {
            if (CurrentScene != null && choiceIndex >= 0 && choiceIndex < CurrentScene.Choices.Count)
            {
                string selectedChoice = CurrentScene.Choices[choiceIndex].Description;
                string imagePath = $"pictures/{selectedChoice}.png";
                Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
                Scene newScene = CurrentScene.Choices[choiceIndex].NextScene;
                if (newScene != null)
                {
                    CurrentScene = newScene;
                }
                if(optionsPanelViewModel.DisplayTextLetterByLetter)
                    StartTextDisplayTimer(CurrentScene.Description);
                else 
                    TextDescription = CurrentScene.Description;
                    OnPropertyChanged(nameof(Source));
            }
            SelectedChoiceIndex = choiceIndex;
            UpdateChoices();
        }

        private void UpdateChoices()
        {
            Choices.Clear();

            if (CurrentScene != null)
            {
                for (int i = 0; i < CurrentScene.Choices.Count; i++)
                {
                    Choices.Add(CurrentScene.Choices[i].Description);
                }
            }
            OnPropertyChanged(nameof(DisplayedChoices));
        }

        public ObservableCollection<string> DisplayedChoices
        {
            get
            {
                var displayedChoices = new ObservableCollection<string>();

                for (int i = 0; i < CurrentScene.Choices.Count; i++)
                {
                    var choice = CurrentScene.Choices[i];

                    string displayedChoice = CurrentScene.Choices[i].Description;

                    if (i == SelectedChoiceIndex)
                    {
                        displayedChoice = $">> {choice.Description}";
                    }

                    displayedChoices.Add(displayedChoice);
                }
                return displayedChoices;
            }
        }

        

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
