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
            db.Users.Add(User);
            ViewBag.user = User.Email;
            ViewBag.user = User.Password;
            ViewBag.Name = User.FirstName;
            db.SaveChanges();
            return View("Index", db.Users);
        }

        [HttpGet]
        public ActionResult NewAccount()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewAccount(User NUser, Program Prog)
        {
            db.Users.Add(NUser);
            db.Programs.Add(Prog);
            ViewBag.user = NUser.FirstName;
            ViewBag.user = NUser.LastName;
            ViewBag.user = NUser.Email;
            db.SaveChanges();
            return View("Password", db.Users);
        }

        [HttpGet]
        public ActionResult Password()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Password(Password P, User U)
        {
            db.Password.Add(P);
            ViewBag.User = U.Password;
            db.SaveChanges();
            return View("PasswordGenerator", db.Password);
        }

        [HttpGet]
        public ActionResult PasswordGenerator()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordGenerator(Password P)
        {
            string Name = P.LastName;
            string Year =  P.BirthYear;
            string Color = P.Color;

            string newstring = Name.Trim(); // results in "this is my String"
            string noSpaceString = Name.Replace(" ", "");

            string newstring2 = Year.Trim(); // results in "this is my String"
            string noSpaceString2 = Year.Replace(" ", "");

            string newstring3 = Color.Trim(); // results in "this is my String"
            string noSpaceString3 = Color.Replace(" ", "");

            char[] charArray = noSpaceString.ToCharArray();
            Array.Reverse(charArray);
            string rev = new string(charArray);

            char[] charArray2 = noSpaceString2.ToCharArray();
            Array.Reverse(charArray2);
            string rev2 = new string(charArray2);

            char[] charArray3 = noSpaceString3.ToCharArray();
            Array.Reverse(charArray3);
            string rev3 = new string(charArray3);

            string password1 = noSpaceString2.Insert(2, noSpaceString) + rev2;
            if (password1.Length < 8)
            {
                password1 += noSpaceString2;
            }

            string password2 = noSpaceString3 + rev + noSpaceString2;
            if (password2.Length < 8)
            {
                password2 += rev2;
            }

            string password3 = noSpaceString2 + noSpaceString3 + noSpaceString.ElementAt(0);
            if (password3.Length < 8)
            {
                password3 += rev2;
            }

            string password4 = Name.Insert(noSpaceString.Length / 2, noSpaceString3 + noSpaceString2);
            if (password4.Length < 8)
            {
                password4 += rev2;
            }

            string password5 = rev.ElementAt(0) + noSpaceString3 + noSpaceString2 + noSpaceString3;
            if (password5.Length < 8)
            {
                password5 += rev2;
            }
            ViewBag.Password1 = password1;
            ViewBag.Password2 = password2;
            ViewBag.Password3 = password3;
            ViewBag.Password4 = password4;
            ViewBag.Password5 = password5;
            //db.Users.Add(UserP);
            //ViewBag.User = UserP.Password;
            //db.SaveChanges();
            return View("Login", db.Users);
        }
    }
}