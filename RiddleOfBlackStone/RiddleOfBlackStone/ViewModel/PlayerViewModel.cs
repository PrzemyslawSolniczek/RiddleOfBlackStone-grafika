using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.ViewModel
{
    public class PlayerViewModel : INotifyPropertyChanged
    {
        private readonly Player player;

        public PlayerViewModel(Player _player)
        {
            player = _player;
        }

        public int Lives
        {
            get { return player.Lives; }
            set
            {
                if (player.Lives != value)
                {
                    player.Lives = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
