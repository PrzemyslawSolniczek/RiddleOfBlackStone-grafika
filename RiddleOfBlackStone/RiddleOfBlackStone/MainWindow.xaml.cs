using RiddleOfBlackStone;
using RiddleOfBlackStone.Model;
using RiddleOfBlackStone.ViewModel;
using System.IO;
using System.Windows;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        private readonly MenuViewModel menuViewModel;
        private OptionsPanelViewModel optionsPanelViewModel;
        OptionsPanel optionsPanel = new OptionsPanel();
        public MainWindow()
        {
            InitializeComponent();

            optionsPanelViewModel = new OptionsPanelViewModel();
            menuViewModel = new MenuViewModel(new MenuModel());
            DataContext = menuViewModel;
            menuViewModel.Path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Sound\WelcomeScreen.wav";
            menuViewModel.SoundPlayer.SoundLocation = menuViewModel.Path;
            menuViewModel.SoundPlayer.PlayLooping();
            // Ustawienie początkowego zaznaczenia
            menuListBox.SelectedIndex = 0;
        }

        private void MenuListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Obsługa zmiany zaznaczenia
            // Tutaj możesz dodać logikę obsługi wyboru użytkownika
            // np. wywołanie odpowiednich funkcji dla poszczególnych opcji
            int selectedIndex = menuListBox.SelectedIndex;
            menuViewModel.UserChoice = selectedIndex;
            menuViewModel.HandleUserChoice();
            switch (selectedIndex)
            {
                case 0:

                    // Rozpocznij nową grę
                    break;
                case 1:
                    // Odczytaj grę
                    break;
                case 2:
                    // O autorach
                    break;
                case 3:
                    optionsPanel.ShowDialog();
                    // Opcje
                    break;
                case 4:
                    // Wyjdź z gry
                    Close();
                    break;
            }
        }
    }
}
