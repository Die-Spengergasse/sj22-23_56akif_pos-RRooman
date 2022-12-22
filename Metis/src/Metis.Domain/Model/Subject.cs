using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class Subject
    {
        public string Name { get; private set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Knowledge SubjectKnowledge { get; } = Knowledge.Unknown;

        private List<Question> _questions { get; set; } = new();
        public virtual IReadOnlyList<Question> Questions => _questions;

        private List<Topic> _topics { get; set; } = new();
        public virtual IReadOnlyList<Topic> Topics => _topics;


        protected Subject()
        { }

        public Subject(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
