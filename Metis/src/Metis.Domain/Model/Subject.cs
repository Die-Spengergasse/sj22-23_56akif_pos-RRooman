using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Question> Questions { get; set; } = new();
        public List<Topic> Topic { get; set; } = new();
        public Knowledge SubjectKnowledge { get; } = Knowledge.Unknown;
    }
}
