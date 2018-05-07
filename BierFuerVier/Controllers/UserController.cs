using BierFuerVier.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BierFuerVier.Controllers
{
    public class UserController : Controller
    {
        private DbAccess db;

        public UserController()
        {
            db = new DbAccess();
        }

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            User dbUser = db.User.SingleOrDefault(u => u.Email == user.Email);
            if (dbUser != null && dbUser.Password == user.Password)
            {
                Session["User"] = user;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.ErrorMessage = "Benutzername oder Passwort fehlerhaft";
                return View(user);
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            db?.Dispose();
        }
    }
}