using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.ViewModel
{
    public class ScenesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static Scene InitializeStory()
        {
            Scene GameOver = new Scene
            {
                Description = "",
                Choices = new List<Choice>(),
            };
            // tworzenie zakonczen
            Scene endingA = new Scene
            {
                Description = "Zakończenie A: Okazuje się, że kamień był przeklęty.\nPrzez Twoje decyzje świat pogrąża się w chaosie, a tajemnicza moc kamienia jest \n teraz nie do opanowania.\n",
                Choices = new List<Choice>(), // lista bedzie pusta
            };

            Scene endingB = new Scene
            {
                Description = "Zakończenie B: Dzięki Twoim badaniom i decyzjom, \nstarożytna technologia przywraca równowagę środowiskową na Ziemi.\nŚwiat odnawia się i wchodzi w nową erę dobrobytu.",
                Choices = new List<Choice>(), // lista bedzie pusta
            };

            // tworzenie scen
            Scene scene1 = new Scene
            {
                Description = "Właśnie odkryłeś tajemniczy czarny kamień z nieznanych znaków.\nKamień ten może prowadzić do wielkiego skarbu lub przeklętej katastrofy.",
                Choices = new List<Choice>(),
            };

            Scene scene2 = new Scene
            {
                Description = "Znaki na kamieniu zaczynają świecić i ukazują Ci drogę do ukrytego pomieszczenia w jaskini.\nW środku jest ołtarz z miejscem na kamień.",
                Choices = new List<Choice>()
            };

            Scene scene3 = new Scene
            {
                Description = "Po wyjściu z jaskini spotykasz tajemniczą postać w kapturze,\nktóra proponuje Ci wielką sumę pieniędzy za kamień.",
                
                Choices = new List<Choice>()
            };

            Scene scene4 = new Scene
            {
                Description = "Po włożeniu kamienia ołtarz zaczyna się obracać, ukazując tajemne przejście.",
                Choices = new List<Choice>()
            };

            Scene scene5 = new Scene
            {
                Description = "Decydujesz się zbadanie kamienia w swoim laboratorium.\nPo dokładnych badaniach możesz coś odkryć.",
                Choices = new List<Choice>()
            };

            // tworzymy wybory i dodajemy je do listy wyborow w konkretnej scenie
            scene1.Choices.Add(new Choice { Description = "Przyjrzeć się kamieniowi", NextScene = scene2 });
            scene1.Choices.Add(new Choice { Description = "Opuścić jaskinię", NextScene = scene3 });

            scene2.Choices.Add(new Choice { Description = "Włożyć kamień na ołtarz", NextScene = scene4 });
            scene2.Choices.Add(new Choice { Description = "Zabrać kamień", NextScene = scene5 });

            scene3.Choices.Add(new Choice { Description = "Sprzedać kamień", NextScene = endingA }); // prowadzi do zakonczenia A
            scene3.Choices.Add(new Choice { Description = "Kontynuować badanie", NextScene = scene5 });

            scene4.Choices.Add(new Choice { Description = "Wejść w przejście", NextScene = endingA }); // prowadzi do zakonczenia A
            scene4.Choices.Add(new Choice { Description = "Wrócić z kamieniem", NextScene = scene5 });

            scene5.Choices.Add(new Choice { Description = "Wykorzystać technologię", NextScene = endingB }); // prowadzi do zakonczenia B
            scene5.Choices.Add(new Choice { Description = "Ukryć kamień", NextScene = endingA }); // prowadzi do zakonczenia A
            return scene1; // inicjalizujemy pierwsza scene
        }
    }
}

