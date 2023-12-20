using RiddleOfBlackStone;
using RiddleOfBlackStone.Command;
using RiddleOfBlackStone.Model;
using RiddleOfBlackStone.ViewModel;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private readonly MenuViewModel menuViewModel;
        private readonly OptionsPanelViewModel optionsPanelViewModel;
        private readonly GameViewModel gameViewModel;


        OptionsPanel optionsPanel = new OptionsPanel();
        GamePage gamePage;
        AuthorView authorView = new AuthorView();
        
        public MainWindow()
        {
            InitializeComponent();

            optionsPanelViewModel = new OptionsPanelViewModel();
            menuViewModel = new MenuViewModel(new MenuModel(), new GameModel(), this);
            gameViewModel = new GameViewModel(new GameModel(), this);
            //DataContext = menuViewModel;
            menuViewModel.PathToMusic = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sound\WelcomeScreen.wav";
            menuViewModel.SoundPlayer.SoundLocation = menuViewModel.PathToMusic;
            MediaElement();
            menuListBox.SelectedIndex = -1;
            gameViewModel.NavigationBackRequested += HandleNavigationBackRequested;
            DataContext = menuViewModel;
        }
        private void HandleNavigationBackRequested(object sender, EventArgs e)
        {
            GameEnd();
        }

        private void GameEnd()
        {
            mainFrame.NavigationService.GoBack();
        }
        private void MediaElement()
        {
            if (optionsPanelViewModel.StopAndPlay())
            {
                mediaElement.Source = new Uri(menuViewModel.SoundPlayer.SoundLocation, UriKind.Relative);
            }
            else
            {
                mediaElement.Source = null;
            }
        }
        private void MenuListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int selectedIndex = menuListBox.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0:
                        //mainFrame.Navigate(quizPage);
                        break;
                    case 1:
                        gamePage = new GamePage(gameViewModel);
                        mainFrame.Navigate(gamePage);
                        Keyboard.ClearFocus();
                        break;
                    case 2:
                        Scene scene = menuViewModel.Load(gameViewModel);
                        gameViewModel.CurrentScene = scene;
                        gameViewModel.IsLoaded = true;
                        gamePage = new GamePage(gameViewModel);
                        mainFrame.Navigate(gamePage);
                        break;
                    case 3:
                    var authorView = new AuthorView();
                        authorView.ShowDialog();
                        break;
                    case 4:
                        optionsPanelViewModel.SaveOptionsToFile("options.xml");
                        var optionsPanel = new OptionsPanel();
                        optionsPanel.ShowDialog();
                        MediaElement();
                    // Opcje
                    break;
                    case 5:
                        QuizPage quizPage = new QuizPage();
                        quizPage.Show();
                        break;
                    case 6:
                        Application.Current.Shutdown();
                        break;

            }
        }
    }
}
