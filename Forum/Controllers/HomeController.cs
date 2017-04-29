using Forum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class HomeController : Controller
    {
        public ApplicationDbContext Database = new ApplicationDbContext();

        public ActionResult Index(int pageIndex = 1, int pageSize = 5)
        {
            ViewBag.currentPage = pageIndex;

            var list = Database.Posts
                        .OrderBy(o => o.DatePosted)
                        .Skip((pageIndex - 1) * pageSize)
                        .Take(pageSize).ToList();

            return View(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}