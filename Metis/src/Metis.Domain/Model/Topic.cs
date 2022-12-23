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
        
        //public Knowledge TopicKnowledge { get; } = Knowledge.Unknown;
        public Subject Subject { get; set; } = default!;

        public IList<QuestionTopic>? QuestionTopics { get; set; }

        //private List<Question> _questions { get; set; } = new();
        //public virtual IReadOnlyList<Question> Questions => _questions;


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
