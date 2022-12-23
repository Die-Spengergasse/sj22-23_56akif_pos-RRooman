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
        //public Knowledge SubjectKnowledge { get; } = Knowledge.Unknown;


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


        public void AddQuestion(Question question)
        {
            if (question is not null) _questions.Add(question);
            else throw new ArgumentNullException("question is NULL!");
        }

        public void AddQuestions(List<Question> questions)
        {
            _questions.AddRange(questions);
        }


        public void AddTopic(Topic topic)
        {
            _topics.Add(topic);
        }

        public void AddTopics(List<Topic> topics)
        {
            _topics.AddRange(topics);
        }
    }
}
