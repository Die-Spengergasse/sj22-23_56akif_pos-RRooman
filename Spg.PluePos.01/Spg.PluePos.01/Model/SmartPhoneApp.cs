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
        public string SmartPhoneId { get; set; } = string.Empty;
        public List<Post> Posts { get; set; } = new();


        public new void Add(Post post)
        {
            if (post is not null) Posts.Add(post); 
        }

        public string? this[string titel]
        {
            get
            {
                string Temp = string.Empty;
                foreach (var post in Posts) { if (post.Title == titel) Temp = post.Html; }
                return (Temp == string.Empty)? null : Temp;
            }
        }


        public SmartPhoneApp(string smartPhoneId) { SmartPhoneId = smartPhoneId; }


        public string ProcessPosts()
        {
            string temp = string.Empty;

            foreach(var post in Posts) { temp += post.Html; }

            return temp;
        }

        public int CalcRating()
        {
            int temp = 0;
            foreach(var post in Posts) { temp += post.Rating; }
            return temp;
        }

        
    }
}
