using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class QuestionTopic
    {
        public int? QuestionId { get; set; }
        public Question Question { get; set; } = default!;

        public string? TopicName { get; set; }
        public Topic Topic { get; set; } = default!;


        public QuestionTopic()
        { }

        public QuestionTopic(Question question, Topic topic)
        {
            Question = question;
            Topic= topic;
        }
    }
}
