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

        public DateTime Until { get; set; }
        public bool Done { get; set; } = false;

        public Question? Question { get; } = default!;
        public Topic? Topic { get; } = default!;
        public Subject? Subject { get; } = default!;


        protected ToDo()
        { }

        public ToDo(DateTime until, Question question)
        {
            Until = until;
            Question = question;
        }

        public ToDo(DateTime until, Subject subject)
        {
            Until = until;
            Subject = subject;
        }

        public ToDo(DateTime until, Topic topic)
        {
            Until = until;
            Topic = topic;
        }


        public void SetDone() => Done = true;

        public void ChangeUntil(DateTime date)
        {
            if (date > DateTime.Now) Until = date;
            else Console.WriteLine("Ungültiges Datum. Datum muss in der Vergangenheit liegen.");
        }
    }
}
