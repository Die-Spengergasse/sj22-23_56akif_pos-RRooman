using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public enum QuestionType { Understanding, Syntax }
    public enum AnswerType { MultipleChoice, OpenQuestion }
    public enum Answered { Correct, Incorrect }
    public enum Knowledge { Unknown, Perfect, Good, Average, Bad, Fatal }

    public class Question
    {

        public int Id { get; set; }
        public string QuestionText { get; set; } = string.Empty;
        public Answer Answer { get; } = default!;
        public QuestionType QuestionType { get; set; }
        public AnswerType AnswerType { get; set; }
        public List<Answered> Answereds { get; set; } = new();
        public Knowledge Knowledge { get; set; } = Knowledge.Unknown;
        public int TimesAsked { get; set; }
        public Flaged Flaged { get; set; } = default!;
        public List<Topic> Topic { get; } = new();
        public List<ToDo> ToDo { get; set; } = new();

    }
}
