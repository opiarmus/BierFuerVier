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
    }
}