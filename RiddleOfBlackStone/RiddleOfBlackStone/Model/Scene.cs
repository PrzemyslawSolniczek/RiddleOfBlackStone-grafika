using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.Model
{
    public class Scene
    {
        public string Description { get; set; } // opis sceny
        public string AsciiArt { get; set; }    // grafika ASCII 
        public List<Choice> Choices { get; set; } // dostepne wybory dla konkretnej sceny
        public ConsoleColor? SceneColor { get; set; } // bedzie ustawiany dla zakonczen

        public Scene()
        {
            Choices = new List<Choice>();
        }
    }
}
