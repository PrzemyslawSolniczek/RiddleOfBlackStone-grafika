using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourAdventure.Model
{
    public class QuizInitializer
    {
        public static List<Question> InitializeQuiz()
        {
            List<Question> quiz = new List<Question>();
            Question question1 = new Question
            {
                Description = "Co jest potrzebne, aby zrealizować wzorzec Unikat (Singleton)?",
                Answers = new List<Answer>()
            };
            question1.Answers.Add(new Answer { Description = "publiczny konstruktor i publiczna statyczna metoda dostępowa", correctAnswer = false });
            question1.Answers.Add(new Answer { Description = "publiczny konstruktor i prywatna statyczna metoda dostępowa", correctAnswer = false });
            question1.Answers.Add(new Answer { Description = "prywatny konstruktor i publiczna statyczna metoda dostępowa", correctAnswer = true });
            question1.Answers.Add(new Answer { Description = "prywatny konstruktor i prywatna statyczna metoda dostępowa", correctAnswer = false });
            quiz.Add(question1);
            Question question2 = new Question
            {
                Description = "Co to jest metaklasa?",
                Answers = new List<Answer>()
            };
            question2.Answers.Add(new Answer { Description = "klasa, która nie została do napisana do końca", correctAnswer = false });
            question2.Answers.Add(new Answer { Description = "klasa, której obiekty same są klasami", correctAnswer = true });
            question2.Answers.Add(new Answer { Description = "klasa, która nie może służyć do tworzenia obiektów", correctAnswer = false });
            question2.Answers.Add(new Answer { Description = "klasa napisana w metajęzyku ", correctAnswer = false });
            quiz.Add(question2);

            Question question3 = new Question
            {
                Description = "Co to jest statyczne typowanie?",
                Answers = new List<Answer>()
            };
            question3.Answers.Add(new Answer { Description = "kontrola typów w czasie wykonania programu ", correctAnswer = false });
            question3.Answers.Add(new Answer { Description = "niemożliwość zmiany typu obiektu po jego stworzeniu ", correctAnswer = false });
            question3.Answers.Add(new Answer { Description = "rezygnacja z kontroli typów w języku programowania", correctAnswer = false });
            question3.Answers.Add(new Answer { Description = "kontrola typów w czasie kompilacji programu", correctAnswer = true });
            quiz.Add(question3);
            Question question4 = new Question
            {
                Description = "Co to jest dynamiczne typowanie w jęzku programowania?",
                Answers = new List<Answer>()
            };
            question4.Answers.Add(new Answer { Description = "kontrola typów w czasie kompilacji programu", correctAnswer = false });
            question4.Answers.Add(new Answer { Description = "dynamiczne tworzenie nowych typów", correctAnswer = false });
            question4.Answers.Add(new Answer { Description = "kontrola typów w czasie wykonania programu", correctAnswer = true });
            question4.Answers.Add(new Answer { Description = "dynamiczna zmiana typu obiektu", correctAnswer = false });
            quiz.Add(question4);
            return quiz;

        }

    }
}