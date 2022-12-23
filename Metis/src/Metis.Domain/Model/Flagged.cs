using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class Flagged
    {
        public int Id { get; private set; }
        public string FlaggingReason { get; set; } = String.Empty;
        public Question Question { get; set; } = default!;
        public Topic Topic { get; set; } = default!;
        public Subject Subject { get; set; } = default!;


        protected Flagged()
        { }

        public Flagged(string flaggingReason, Question question)
        {
            FlaggingReason = flaggingReason;
            Question = question;
        }

        public Flagged(string flaggingReason, Subject subject)
        {
            FlaggingReason = flaggingReason;
            Subject = subject;
        }

        public Flagged(string flaggingreason, Topic topic)
        {
            FlaggingReason = flaggingreason;
            Topic = topic;
        }
    }
}
