using RiddleOfBlackStone.Model;
using RiddleOfBlackStone.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
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
using Microsoft.Xaml.Behaviors;
using System.Windows.Media.Animation;

namespace RiddleOfBlackStone
{
    /// <summary>
    /// Logika interakcji dla klasy GameView.xaml
    /// </summary>
    public partial class GamePage : Page
    {
        private readonly GameViewModel gameViewModel;
        //private readonly QuizPage quizPage = new QuizPage(gameViewModel);
        private bool check = false;
        public int newIndex;
        public GamePage(GameViewModel _gameViewModel)
        {
            InitializeComponent();
            gameViewModel = _gameViewModel;
            gameViewModel.StartGame();
            gameViewModel.Choices = new ObservableCollection<string>();
            DataContext = gameViewModel;
            choiceListBox.SelectionChanged += ChoiceListBox_SelectionChanged;
            TextDescription.Loaded += TextDescription_Loaded;

        }
        private void TextDescription_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(2)
            };

            TextDescription.BeginAnimation(TextBlock.OpacityProperty, opacityAnimation);
        }
        private void ChoiceListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                e.Handled = true;

                int offset = (e.Key == Key.Up) ? 0 : 1;

                MoveSelection(offset);
            }
            if (e.Key == Key.Enter && check)
            {
                gameViewModel.ChoiceIndex = newIndex;
                check = false;
                gameViewModel.HandleChoiceSelected(newIndex);
            }
        }

        private void MoveSelection(int offset)
        {
            newIndex = offset;
            if (newIndex >= 0 && newIndex < choiceListBox.Items.Count)
            {
                choiceListBox.SelectedIndex = newIndex;
                check = true;
            }
        }

        private void ChoiceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DoubleAnimation opacityAnimation = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = TimeSpan.FromSeconds(2)
            };

            TextDescription.BeginAnimation(TextBlock.OpacityProperty, opacityAnimation);
        }

        private void choiceListBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        /*
private void choiceListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{
   int selectedIndex = choiceListBox.SelectedIndex;
   string selectedChoice = choiceListBox.SelectedItem as string;

   if (!string.IsNullOrEmpty(selectedChoice))
   {
       string imagePath = $"pictures/{selectedChoice}.png";
       gameImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
   }

   if (selectedIndex >= 0 && selectedIndex < gameViewModel.CurrentScene.Choices.Count)
   {
       gameViewModel.HandleChoiceSelected(selectedIndex);
       UpdateChoices(); 
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
/*
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
*/
    }
}
