﻿using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Assignment2.Controllers
{
    public class HomeController : Controller
    {
        private VisitorLogContext db = new VisitorLogContext();
        public ActionResult Index()
        {
            return View();
        }

        

    }
}