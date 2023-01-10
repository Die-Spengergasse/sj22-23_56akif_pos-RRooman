using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public enum QuestionType { Understanding, Syntax }
    public enum AnswerType { MultipleChoice, OpenQuestion }

    public class Question
    {
        public int Id { get; private set; }
        public string QuestionText { get; set; } = string.Empty;
        public Answer? Answer { get; set; } = default!;
        
        public QuestionType QuestionType { get; set; }
        public AnswerType AnswerType { get; set; }
        
        public Statistic QStat { get; }

        public IReadOnlyList<QuestionTopic>? QuestionTopics { get; set; }

        //private List<Topic> _topics { get; set; } = new();
        //public virtual IReadOnlyList<Topic> Topics => _topics;

        private List<Result> _answereds { get; set; } = new();
        public virtual IReadOnlyList<Result>? Answereds => _answereds;

        private List<ToDo> _toDo { get; set; } = new();
        public virtual IReadOnlyList<ToDo>? ToDo => _toDo;


        public Question()
        {
            QStat = new Statistic(this);
        }

        public Question(
            string questionText,
            QuestionType questionType,
            AnswerType answerType)
        {
            QuestionText = questionText;
            QuestionType = questionType;
            AnswerType = answerType;
            QStat = new Statistic(this);
        }

        //public Question(
        //    string questionText,
        //    QuestionType questionType, 
        //    AnswerType answerType, 
        //    List<Topic> topics)
        //{
        //    QuestionText = questionText;
        //    QuestionType = questionType;
        //    AnswerType = answerType;
        //    _topics = topics;
        //    QStat = new Statistic(this);
        //}
    }
}
