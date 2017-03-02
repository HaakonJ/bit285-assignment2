using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assignment2.Models;
using Assignment2.ViewModels;

namespace Assignment2.Controllers
{
    public class AccountController : Controller
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
            public ActionResult Login(LoginViewModel Temp)
            {
                
                ViewBag.ETemp = Temp.Email;
                ViewBag.PTemp = Temp.Password;
                //db.SaveChanges();
                return View("Welcome");
            }

            [HttpGet]
            public ActionResult NewAccount()
            {
                return View();
            }

            [HttpPost]
            public ActionResult NewAccount(NewAccountViewModel NUser)
            {
                //db.Users.Add(NUser);
                //db.Programs.Add(Prog);
                ViewBag.First = NUser.FirstName;
                ViewBag.Last = NUser.LastName;
                ViewBag.Email = NUser.Email;
                ViewBag.Program = NUser.Program;
                ViewBag.EmailUp = NUser.EmailUpdates;
            //db.SaveChanges();
            return View("Password", db.Users);
            }

            [HttpGet]
            public ActionResult Password()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Password(PasswordViewModel P)
            {
               
                ViewBag.LN = P.LastName;
                ViewBag.BY = P.BirthYear;
                ViewBag.FC = P.Color;
                // db.SaveChanges();
                

            string Name = ViewBag.LN;
            string Year = ViewBag.BY;
            string Color = ViewBag.FC;

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

            return View("PasswordGenerator");
        }

            [HttpGet]
            public ActionResult PasswordGenerator()
            {
                return View();
            }

            [HttpPost]
            public ActionResult PasswordGenerator(PasswordViewModel P)
            {
                
                //db.Users.Add(UserP);
                //ViewBag.User = UserP.Password;
                //db.SaveChanges();
                return View("Login");
            }


            /**
             * Store temporary user in Session during account creation
             */
            private User GetTempUser()
            {
                if (Session["tempUser"] == null)
                {
                    Session["tempUser"] = new User();
                }
                return (User)Session["tempUser"];
            }

            private void FlushTempUser()
            {
                Session.Remove("tempUser");
            }
        }
    }