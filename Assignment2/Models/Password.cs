using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Assignment2.Models
{
    public class Password
    {
        [Key]
        public int PasswordID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Birth Year")]
        public string BirthYear { get; set; }

        [Required]
        [Display(Name = "Favorite Color")]
        public string Color { get; set; }
    }
}