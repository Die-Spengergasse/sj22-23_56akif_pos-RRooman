﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spg.PluePos._01.Model
{
    public class ImagePost : Post
    {
        public string? Url { get; set; }
        public override string Html => Url is null ? $"„<h1>{Title}</h1><img src={Url} />" : throw new ArgumentNullException("Url war NULL");

        public ImagePost(string title, DateTime created) : base(title, created) { }
        public ImagePost(string title) : base(title) { }

    }
}
