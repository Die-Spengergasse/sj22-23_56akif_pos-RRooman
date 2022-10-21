using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class ToDo
    {
        public int Id { get; set; }
        public List<Question>? MarkedQuestions { get; }
        public List<Topic>? MarkedTopics { get; }
        public List<Subject>? MarkedSubjects { get; }
        public DateTime Until { get; set; } = DateTime.MaxValue;
        public bool Done { get; set; } = false;
    }
}
