using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    
    
    public class Statistic
    {
        public List<Question> Questions = new();
        public int QuestionCount { get; }
        public double AverageKnowledge { get; }
        public int TotalQuestionsAsked { get; }
        public Knowledge TotalKnowledge { get; }
        

    }
}
