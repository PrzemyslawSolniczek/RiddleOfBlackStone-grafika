using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.ViewModel
{
    public class AnswerViewModel : INotifyPropertyChanged
    {
        public string Description { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
