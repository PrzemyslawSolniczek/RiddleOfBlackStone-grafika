using RiddleOfBlackStone;
using RiddleOfBlackStone.Command;
using RiddleOfBlackStone.Model;
using RiddleOfBlackStone.ViewModel;
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
        private bool isProgrammaticSelection = false;


        OptionsPanel optionsPanel = new OptionsPanel();
        GamePage gamePage;
        AuthorView authorView = new AuthorView();
        public MainWindow()
        {
            InitializeComponent();

            optionsPanelViewModel = new OptionsPanelViewModel();
            menuViewModel = new MenuViewModel(new MenuModel(), new GameModel());
            gameViewModel = new GameViewModel(new GameModel());
            gamePage = new GamePage(gameViewModel);
            DataContext = menuViewModel;
            
            menuViewModel.Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sound\WelcomeScreen.wav";
            menuViewModel.SoundPlayer.SoundLocation = menuViewModel.Path;
            //menuViewModel.SoundPlayer.PlayLooping();
            // Ustawienie początkowego zaznaczenia
            menuListBox.SelectedIndex = 0;
            DataContext = menuViewModel;
        }

        private void MenuListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            int selectedIndex = menuListBox.SelectedIndex;
                switch (selectedIndex)
                {
                    case 0:
                        break;
                    case 1:
                        mainFrame.Navigate(gamePage);
                        break;
                    case 2:
                        // Odczytaj grę
                        break;
                    case 3:
                    var authorView = new AuthorView();
                        authorView.ShowDialog();
                        break;
                    case 4:
                        var optionsPanel = new OptionsPanel();
                        optionsPanel.ShowDialog();
                        // Opcje
                        break;
                    case 5:
                        // Wyjdź z gry
                        Close();
                        break;
                }
        }
    }
}
