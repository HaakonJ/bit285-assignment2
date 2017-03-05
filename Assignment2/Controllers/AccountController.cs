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
            public ActionResult Login()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Login(LoginViewModel user)
            {
            
                //ViewBag.ETemp = Temp.Email;
                //ViewBag.PTemp = Temp.Password;

            if (isUser(user.UserName))
            {
                Activity newActivity = new Activity();
                newActivity.ActivityDate = DateTime.Now;
                newActivity.ActivityName = user.UserName;
                newActivity.IpAddress = Request.UserHostAddress;

                db.Activities.Add(newActivity);
                //db.SaveChanges();

                return View(".../HomeController/Index", db.Activities);
            }
            else
            {
                ModelState.Clear();
                ModelState.AddModelError("ErrorMessage", "THIS IS NOT A VALID ACCOUNT. PLEASE TRY AGAIN!");

                return View("Login");
            }

            //db.SaveChanges();
            //return View("Welcome");
            }

            [HttpGet]
            public ActionResult NewAccount()
            {
            var model = new NewAccountViewModel();
            IQueryable<Program> rtn = db.Programs;
            //model.ProgramOp = rtn;
            return View("NewAccount");
            }

            [HttpPost]
            public ActionResult NewAccount(NewAccountViewModel NUser, string create, string reset)
            {


            ViewBag.Last = NUser.LastName;
            if (!string.IsNullOrEmpty(create))

            {
                if (!isUser(NUser.FirstName))
                {
                    User newUser = new User();

                    newUser.FirstName = NUser.FirstName;
                    newUser.LastName = NUser.LastName;
                    newUser.Email = NUser.Email;
                    newUser.EmailUpdates = NUser.EmailUpdates;
                    //newUser.ProgramID = NUser.Program.ProgramID;
                    Session["tempUser"] = newUser;
                    return Redirect("Password");
                }
                else
                {
                    return View("NewAccount");
                }
            }
            else if(!string.IsNullOrEmpty(reset))
            {
                ModelState.Clear();
                return View("NewAccount");
            }
            else
            {
                return View("NewAccount");
            }
            //db.Users.Add(NUser);
            //db.Programs.Add(Prog);
            //    ViewBag.First = NUser.FirstName;
            //    ViewBag.Last = NUser.LastName;
            //    ViewBag.Email = NUser.Email;
            //    ViewBag.Program = NUser.Program;
            //    ViewBag.EmailUp = NUser.EmailUpdates;



            //GetTempUser().FirstName = NUser.FirstName;
            //GetTempUser().LastName = NUser.LastName;
            //GetTempUser().Email = NUser.Email;

            //Program Pro = new Program();
            //Pro.ProgramID = GetTempUser().ProgramID;

            //Activity Act = new Activity();
            //Act.ActivityDate = DateTime.Now;


            //ViewBag.FN = GetTempUser().FirstName;

            ////db.SaveChanges();
            //return View("Password");
        }

            [HttpGet]
            public ActionResult Password()
            {
                return View("Password");
            }

            [HttpPost]
            public ActionResult Password(PasswordViewModel P)
            {
            P.LastName = GetTempUser().LastName;

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


            return Redirect("PasswordGenerator");
            //return View("PasswordGenerator");
        }

            [HttpGet]
            public ActionResult PasswordGenerator()
            {
                return View("PasswordGenerator");
            }

            [HttpPost]
            public ActionResult PasswordGenerator(PasswordGeneratorViewModel P)
            {
                ViewBag.Choosen = P.Password;
                //db.Users.Add(UserP);
                //ViewBag.User = UserP.Password;
                //db.SaveChanges();
                return View("Login");
            }

            private bool isUser(string user)
            {
                return db.Users.ToList().Any(m => m.Email == user);
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