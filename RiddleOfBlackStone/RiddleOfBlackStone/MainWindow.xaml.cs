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
        private bool isArrowKeyPressed = false;
        private bool flag = false;


        OptionsPanel optionsPanel = new OptionsPanel();
        GamePage gamePage;
        AuthorView authorView = new AuthorView();
        
        public MainWindow()
        {
            InitializeComponent();

            optionsPanelViewModel = new OptionsPanelViewModel();
            menuViewModel = new MenuViewModel(new MenuModel(), this);
            gameViewModel = new GameViewModel(new GameModel(), this);
            menuViewModel.PathToMusic = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sound\WelcomeScreen.wav";
            menuViewModel.SoundPlayer.SoundLocation = menuViewModel.PathToMusic;
            MediaElement();
            menuListBox.SelectedIndex = -1;
            gameViewModel.NavigationBackRequested += HandleNavigationBackRequested;
            PreviewKeyDown += MenuListBox_PreviewKeyDown;
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
        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            var controlInsideFrame = mainFrame.Content as FrameworkElement;
            if (controlInsideFrame != null)
            {
                controlInsideFrame.Focus();
            }

            mainFrame.Loaded -= MainFrame_Loaded;
        }


        private void MenuListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int selectedIndex = menuListBox.SelectedIndex;
            if (isArrowKeyPressed)
            {
                isArrowKeyPressed = false;
                return;
            }
            switch (selectedIndex)
                {
                    case 0:
                        //mainFrame.Navigate(quizPage);
                        break;
                    case 1:
                        if(!flag)
                        {
                            gamePage = new GamePage(gameViewModel);
                            mainFrame.IsTabStop = true;
                            mainFrame.Focusable = true;
                            flag = true;
                        }
                        mainFrame.Navigate(gamePage);
                        mainFrame.Loaded += MainFrame_Loaded;
                        mainFrame.Focus();
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
                        Application.Current.Shutdown();
                        break;

            }
        }
        private void MenuListBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Down)
            {
                isArrowKeyPressed = true;
            }
            else
            {
                isArrowKeyPressed = false;
            }
        }
        private void MenuListBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(!flag)
            {
                if (e.Key == Key.Enter)
                {
                    int selectedIndex = menuListBox.SelectedIndex;
                    if (selectedIndex >= 0 && selectedIndex < menuListBox.Items.Count)
                    {
                        MenuListBox_SelectionChanged(sender, e);
                    }

                    e.Handled = true;
                }
            }
        }
    }
}
