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
        public string Explanation { get; set; } = string.Empty;
        public List<Question> Questions { get; } = new();
    }
}
