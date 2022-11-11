using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01.Model
{
    public abstract class Post
    {

        public string Title { get; }
        public DateTime Created { get; }

        public SmartPhoneApp SmartPhone => smartPhone;
        public int Rating
        {
            get { return _rating; }
            set
            {
                if (value >= 1 && value <= 5) _rating = value;
                else throw new ArgumentOutOfRangeException("Range muss zwischen 1 und 5 liegen.");
            }
        }
        private int _rating;
        private readonly SmartPhoneApp smartPhone;

        public abstract string Html { get; }


        public Post(string title, DateTime created)
        {
            if (title is null) throw new ArgumentNullException("Titel war null");
            Title = title;
            Created = created;
        }

        public Post(string title) : this(title, DateTime.Now) { }

        public override string ToString()
        {
            return Html;
        }
    }
}
