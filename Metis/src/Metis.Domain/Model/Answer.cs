using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string AnswerText { get; } = string.Empty;
        public string? Explanation { get; set; }
        public string? AdditionalInfo { get; set; }

        public int QuestionNavigationId { get; set; }
        public virtual Question QuestionNavigation { get; set; } = new();


        protected Answer()
        { }

        public Answer(string answerText)
        {
            AnswerText = answerText;
        }

        public Answer(string answerText, string explanation)
        {
            AnswerText = answerText;
            Explanation = explanation;
        }

        public Answer(string answerText, string? explanation, string? additionalInfo)
        {
            AnswerText = answerText;
            Explanation = explanation;
            AdditionalInfo = additionalInfo;
        }
    }
}
