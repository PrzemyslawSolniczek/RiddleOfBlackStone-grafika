using RiddleOfBlackStone.Model;
using RiddleOfBlackStone.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace RiddleOfBlackStone
{
    /// <summary>
    /// Logika interakcji dla klasy GameView.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private readonly GameViewModel gameViewModel;
        public GamePage(GameViewModel _gameViewModel)
        {
            InitializeComponent();
            gameViewModel = _gameViewModel;
            gameViewModel = new GameViewModel(new GameModel());
            gameViewModel.CurrentScene = ScenesViewModel.InitializeStory();
            DataContext = gameViewModel;
            gameViewModel.Choices = new ObservableCollection<string>();
            UpdateChoices();
            for (int i = 0; i < gameViewModel.CurrentScene.Choices.Count; i++)
                gameViewModel.Choices.Add(gameViewModel.CurrentScene.Choices[i].Description);

        }
        private void choiceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = choiceListBox.SelectedIndex;

            if (selectedIndex >= 0 && selectedIndex < gameViewModel.CurrentScene.Choices.Count)
            {
                gameViewModel.HandleChoiceSelected(selectedIndex);
                UpdateChoices(); // Update choices after handling the selection
            }
        }

        private void UpdateChoices()
        {
            gameViewModel.Choices.Clear();

            foreach (var choice in gameViewModel.CurrentScene.Choices)
            {
                gameViewModel.Choices.Add(choice.Description);
            }
        }
        public void DisplayChoices(int choices)
        {
            //choiceListBox.Items.Clear();

            for (int i = 0; i < gameViewModel.CurrentScene.Choices.Count; i++)
            {
                var choice = gameViewModel.CurrentScene.Choices[i];

                ListBoxItem listBoxItem = new ListBoxItem();
                listBoxItem.Content = choice.Description;

                if (i == choices)
                {
                    listBoxItem.Foreground = Brushes.Green;
                    listBoxItem.Content = $">> {choice.Description}";
                }

                choiceListBox.Items.Add(listBoxItem);
            }

            //gameViewModel.DisplayChoicesWithHighlight(2);
        }
    }
}
