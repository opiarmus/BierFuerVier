using BierFuerVier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BierFuerVier.Controllers
{
    public class HomeController : Controller
    {
        private DbAccess db;

        public HomeController()
        {
            db = new DbAccess();
        }

        public ActionResult Index()
        {
            IEnumerable<Beer> model = db.Beer.AsEnumerable();
            return View(model);
        }

        public ActionResult Sample()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Upvote()
        {
            var id = Request.Form["id"];
            int beerId;
            if (Int32.TryParse(id, out beerId))
            {
                var beer = db.Beer.FirstOrDefault(b => b.Id == beerId);
                if (beer != null)
                {
                    beer.Upvotes++;
                    db.SaveChanges();
                    return Json(true);
                }
            }
            
            return Json(false);
        }

        [HttpPost]
        public JsonResult Downvote()
        {
            var id = Request.Form["id"];
            int beerId;
            if (Int32.TryParse(id, out beerId))
            {
                var beer = db.Beer.FirstOrDefault(b => b.Id == beerId);
                if (beer != null)
                {
                    beer.Downvotes++;
                    db.SaveChanges();
                    return Json(true);
                }
            }

            return Json(false);
        }
    }
}