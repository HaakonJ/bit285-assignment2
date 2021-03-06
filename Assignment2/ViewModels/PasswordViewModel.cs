﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.ViewModels
{
    public class PasswordViewModel
    {

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth Year")]
        public string BirthYear { get; set; }

        [Required]
        [Display(Name = "Favorite Color")]
        public string Color { get; set; }

        [Display(Name = "Passwords")]
        public string Passwords { get; set; }
    }
}