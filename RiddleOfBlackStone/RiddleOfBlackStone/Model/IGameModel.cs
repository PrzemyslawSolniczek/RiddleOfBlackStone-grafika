using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.Model
{
    public interface IGameModel : INotifyPropertyChanged
    {
        Scene currentScene { get; set; }
        List<Question> quiz { get; set; }
        AppState appState { get; set; }
        bool isLoaded { get; set; }
        int sum { get; set; }
        int choiceIndex { get; set; }
        Enemies skeleton { get; set; }
        Enemies dragon { get; set; }
        Player player { get; set; }
        int r { get; set; }
    }
}
