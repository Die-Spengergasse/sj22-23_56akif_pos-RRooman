using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public enum Result { Correct, Incorrect }
    public enum Knowledge { Unknown, Perfect, Good, Average, Bad, Fatal }

    public class Statistic
    {
        public int AskedCount { get; set; }
        //public double AverageKnowledge { get; }
        //public int TotalQuestionsAsked { get; }
        public int PercentCorrect { get; set; }
        public Knowledge Knowledge { get; set; } = Knowledge.Unknown;
        public Question Question { get; } = default!;

        private List<Result> _results = new List<Result>();
        public IReadOnlyList<Result> Results => _results;

        //private List<Question> _questions = new();
        //public IReadOnlyList<Question> Questions => _questions;

        protected Statistic()
        { }

        public Statistic(Question question)
        {
            Question = question;
        }

        public void IncrementAsked(Result result)
        {
            AskedCount++;
            _results.Add(result);

            CalculatePercentCorrect();
            Calculate_Knowledge();
        }

        private void CalculatePercentCorrect()
        {
            int correct = _results.Where(item => item == Result.Correct).Count();
            PercentCorrect = correct / AskedCount * 100;
        }

        private void Calculate_Knowledge()
        {
            switch (PercentCorrect)
            {
                case > 90:
                    Knowledge = Knowledge.Perfect;
                    break;
                case > 75:
                    Knowledge = Knowledge.Good;
                    break;
                case > 60:
                    Knowledge = Knowledge.Average;
                    break;
                case > 50:
                    Knowledge = Knowledge.Bad;
                    break;
                default:
                    Knowledge = Knowledge.Fatal;
                    break;
            }
        }
    }
}
