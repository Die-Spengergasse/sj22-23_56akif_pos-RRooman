using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class Topic
    {
        public string Name { get; set; } = string.Empty;
        public string TopicInfo { get; set; } = string.Empty;
        
        public Knowledge TopicKnowledge { get; } = Knowledge.Unknown;
        public Subject Subject { get; set; } = default!;

        private List<Question> _questions { get; set; } = new();
        public virtual IReadOnlyList<Question> Questions => _questions;
        

        //public List<Subject> _subjects { get; set; } = new();
        //public virtual IReadOnlyList<Subject> Subjects => _subjects;
        
        
        //private List <ToDo>? _toDo { get; set; }
        //public IReadOnlyList<ToDo>? ToDo => _toDo;
        //public Flaged Flaged { get; set; } = default!;


        protected Topic()
        { }

        public Topic(string name, string topicInfo, Subject subject)
        {
            Name = name;
            TopicInfo = topicInfo;
            Subject = subject;
        }
    }
}
