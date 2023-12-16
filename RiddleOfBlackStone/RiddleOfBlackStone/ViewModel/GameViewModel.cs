using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.ViewModel
{
    public class GameViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IGameModel gameModel;

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

        /*
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
        }
        */

        public void StartGame()
        {
            CurrentScene = ScenesViewModel.InitializeStory();
        }
        public void HandleChoiceSelected(int choiceIndex)
        {
            if (CurrentScene != null && choiceIndex >= 0 && choiceIndex < CurrentScene.Choices.Count)
            {
                Scene newScene = CurrentScene.Choices[choiceIndex].NextScene;
                if (newScene != null)
                {
                    CurrentScene = newScene;
                }
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
