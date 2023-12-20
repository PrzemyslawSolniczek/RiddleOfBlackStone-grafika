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
            
            optionsPanelViewModel = new OptionsPanelViewModel();
            
            DataContext = optionsPanelViewModel;
        }
       
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            optionsPanelViewModel.SaveOptionsToFile("options.xml");
            MessageBox.Show("Zapisano zmiany.");
        }
    }
}
