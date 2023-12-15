using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.Model
{
    public class Choice
    {
        public string Description { get; set; } // opis konkretnego wyboru
        public Scene NextScene { get; set; }   // bezposrednie nawiazanie do sceny, do ktorej prowadzi ten wybor

    }
}
