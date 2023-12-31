﻿using RiddleOfBlackStone.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RiddleOfBlackStone
{
    /// <summary>
    /// Logika interakcji dla klasy QuizPage.xaml
    /// </summary>
    public partial class QuizPage : Page
    {
        private readonly GameViewModel gameViewModel;
        public QuizPage(GameViewModel gameViewModel)
        {
            InitializeComponent();
            this.gameViewModel = gameViewModel;
            DataContext = new QuizViewModel();
        }
    }
}
