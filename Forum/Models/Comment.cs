using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Body { get; set; }
        public DateTime DatePosted { get; set; } = DateTime.Now;
        public int UpVoteCount { get; set; } = 0;
        public int DownVoteCount { get; set; } = 0;
        public bool MarkedAsAnswer { get; set; } = false;

        public string UserID { get; set; }
        public ApplicationUser User { get; set; }

        public int PostID { get; set; }
        public Post Post { get; set; }
    }
}