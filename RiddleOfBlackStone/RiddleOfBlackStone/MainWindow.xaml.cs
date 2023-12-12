using System.Windows;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Ustawienie początkowego zaznaczenia
            menuListBox.SelectedIndex = 0;
        }

        private void MenuListBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            // Obsługa zmiany zaznaczenia
            // Tutaj możesz dodać logikę obsługi wyboru użytkownika
            // np. wywołanie odpowiednich funkcji dla poszczególnych opcji
            int selectedIndex = menuListBox.SelectedIndex;
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
