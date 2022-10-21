using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metis.Domain.Model
{
    public class Topic
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string TopicInfo { get; } = string.Empty;
        public Knowledge TopicKnowledge { get; } = Knowledge.Unknown;
        public List<Question> Questions { get; set; } = new();
        public List<Subject> Subjects { get; set; } = new();
        public List <ToDo> toDos { get; set; } = new();
        public Flaged Flaged { get; set; } = default!;

    }
}
