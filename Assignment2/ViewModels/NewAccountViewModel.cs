using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Assignment2.Models;
using System.Web.Mvc;

namespace Assignment2.ViewModels
{
    public class NewAccountViewModel
    {
        [Required]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public Program Program;

        //[Required]
        [Display(Name = "Program Options")]
        public string ProgramOp { get; set; }

        [Display(Name = "Email me program updates")]
        public bool EmailUpdates { get; set; }
    }
}