using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class Flaged
    {
        public int Id { get; set; }
        public string FlaggingReason { get; set; } = String.Empty;
        public Question Question { get; set; } = default!;
        public Topic Topic { get; set; } = default!;
        public Subject Subject { get; set; } = default!;

        protected Flaged()
        { }

        public Flaged(string flaggingReason)
        {
            FlaggingReason = flaggingReason;
        }
    }
}
