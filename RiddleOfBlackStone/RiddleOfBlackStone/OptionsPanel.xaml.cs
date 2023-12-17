using RiddleOfBlackStone.Model;
using RiddleOfBlackStone.ViewModel;
using System;
using System.Collections.Generic;
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
    /// Logika interakcji dla klasy OptionsPanel.xaml
    /// </summary>
    public partial class OptionsPanel : Window
    {
        private readonly MenuViewModel menuViewModel;
        private readonly OptionsPanelViewModel optionsPanelViewModel;

        public OptionsPanel()
        {
            InitializeComponent();
            menuViewModel = new MenuViewModel(new MenuModel(), new GameModel());
            
            optionsPanelViewModel = new OptionsPanelViewModel();
            DataContext = optionsPanelViewModel;
        }
        private ListBoxItem FindListBoxItemByContent(ListBox listBox, string content)
        {
            foreach (var item in listBox.Items)
            {
                if (item is ListBoxItem listBoxItem && listBoxItem.Content.ToString() == content)
                {
                    return listBoxItem;
                }
            }
            return null;
        }

        private void MainWindow_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            menuViewModel.SaveOptionsToFile("options.xml");
            MessageBox.Show("Zapisano zmiany.");
        }
    }
}
