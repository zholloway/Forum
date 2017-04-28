using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class VoteController : Controller
    {
        ApplicationDbContext Database = new ApplicationDbContext();

        public ActionResult UpVote(int id)
        {
            var post = Database.Posts.First(f => f.ID == id);
            post.UpVoteCount++;
            Database.SaveChanges();

            return PartialView("_voteCounter", post);
        }

        public ActionResult DownVote(int id)
        {
            var post = Database.Posts.First(f => f.ID == id);
            post.DownVoteCount++;
            Database.SaveChanges();

            return PartialView("_voteCounter", post);
        }
    }
}