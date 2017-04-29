using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Forum.Models;

namespace Forum.Controllers
{
    public class CommentsController : Controller
    {
        ApplicationDbContext Database = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Create(string commentBody, string userID, int postID)
        {
            var newComment = new Comment();
            newComment.Body = commentBody;
            newComment.UserID = userID;
            newComment.PostID = postID;
            Database.Comments.Add(newComment);
            Database.SaveChanges();

            var post = Database.Posts.First(w => w.ID == postID);
            post.Comments.Add(newComment);
            Database.SaveChanges();

            return PartialView("_Comment", newComment);
        }
    }
}