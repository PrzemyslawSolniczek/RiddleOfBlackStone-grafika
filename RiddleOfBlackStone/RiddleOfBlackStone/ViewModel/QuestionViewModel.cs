using RiddleOfBlackStone.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiddleOfBlackStone.ViewModel
{
    public class QuestionViewModel : INotifyPropertyChanged
    {
        private Question _question;
        private int _selectedOption;
        private string _correctAnswerDescription;

        public QuestionViewModel(Question question)
        {
            _question = question;
            _selectedOption = -1;
            _correctAnswerDescription = question.Answers
                .Where(answer => answer.correctAnswer)
                .Select(answer => answer.Description)
                .FirstOrDefault();
        }

        public string Description
        {
            get { return _question.Description; }
        }

        public List<Answer> Answers
        {
            get { return _question.Answers; }
        }
        public string CorrectAnswerDescription
        {
            get { return _correctAnswerDescription; }
        }
        public bool CorrectAnswer
        {
            get { return SelectedOption >= 0 && Answers[SelectedOption].Description == CorrectAnswerDescription; } 
        }

        public int SelectedOption
        {
            get { return _selectedOption; }
            set
            {
                if (_selectedOption != value)
                {
                    _selectedOption = value;
                    OnPropertyChanged(nameof(SelectedOption));
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
