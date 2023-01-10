using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01.Model
{
    public class SmartPhoneApp : List<Post>
    {
        public string SmartPhoneId { get; set; }

        //public List<Post> Posts { get; set; } = new();

        
        public new void Add(Post post)
        {
            if (post is not null)
            {
                post.SmartPhone = this;

                base.Add(post);
            }
        }

        public Post? this[string titel]
        {
            get
            {
                foreach(Post item in this) { if (item.Title == titel) return item; }

                return null;
            }
        }

        public SmartPhoneApp(string smartPhoneId) { SmartPhoneId = smartPhoneId; }


        public string ProcessPosts()
        {
            string temp = string.Empty;

            foreach(Post item in this) { temp += item.Html; }

            return temp;
        }

        public int CalcRating()
        {
            int temp = 0;

            foreach(Post item in this) { temp += item.Rating; }

            return temp;
        }

            
    }
}
