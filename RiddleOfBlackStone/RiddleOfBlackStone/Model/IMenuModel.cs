using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.Model
{
    public interface IMenuModel
    {
        bool DisplayTextLetterByLetter { get; set; }
        bool Music { get; set; }
        string Path { get; set; }
        bool Check { get; set; }
        bool Loaded { get; set; }
        string LoadGame { get; set; }
        SoundPlayer SoundPlayer { get; set; }
        AppState AppState { get; set; }
        bool EndOfGame { get; set; }
        int UserChoice { get; set; }
    }
}
