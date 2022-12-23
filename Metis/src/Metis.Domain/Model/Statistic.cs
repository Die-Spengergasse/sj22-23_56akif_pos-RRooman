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
        public int AskedCount { get; private set; }
        public int PercentCorrect { get; private set; }
        public Knowledge Knowledge { get; private set; } = Knowledge.Unknown;
        public Question Question { get; } = default!;

        private List<Result> _results = new List<Result>();
        public IReadOnlyList<Result> Results => _results;

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
            CalculateKnowledge();
        }

        private void CalculatePercentCorrect()
        {
            double correct = _results.Where(item => item == Result.Correct).Count();
            PercentCorrect = (int)(correct / AskedCount * 100);
        }

        private void CalculateKnowledge()
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
