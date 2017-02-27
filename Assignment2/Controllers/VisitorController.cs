using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;

namespace Assignment2.Controllers
{
    public class VisitorController : Controller
    {
        VisitorLogContext db = new VisitorLogContext();
        // GET: Visitor

         [HttpGet]
        public ActionResult Index()
        {
            return View(db.Users);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User User)
        {
           // db.Users.Add(user);
           // ViewBag.user = user.FirstName;
           // db.SaveChanges();
            return View("Welcome");
        }

        [HttpGet]
        public ActionResult NewAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAccount(User NUser)
        {
            //db.Users.Add(NUser);
            //ViewBag.user = NUser.FirstName;
            //ViewBag.user = NUser.LastName;
            //ViewBag.user = NUser.Email;
           // db.SaveChanges();
            return View("Password");
        }

        [HttpGet]
        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Password(Password P)
        {
            //db.Users.Add(UserP);
            //ViewBag.User = UserP.Password;
            ////db.SaveChanges();
            return View("PasswordGenerator");
        }

        [HttpGet]
        public ActionResult PasswordGenerator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordGenerator(Password P)
        {
            //db.Users.Add(UserP);
            //ViewBag.User = UserP.Password;
            ////db.SaveChanges();
            return View("Login");
        }
    }
}