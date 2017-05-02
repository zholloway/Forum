using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Post
    {
        public int? ID { get; set; }
        public string Title { get; set; }
        public string Img { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public int? UpVoteCount { get; set; } = 1;
        public int? DownVoteCount { get; set; } = 0;
        public string Body { get; set; }
        public List<Comment> Comments { get; set; }

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }
    }
}