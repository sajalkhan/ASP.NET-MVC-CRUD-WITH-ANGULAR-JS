using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularJs_Practice.Models
{
    public class EmployeeVm
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter ContactNo1")]
        public string ContactNo1 { get; set; }
        [Required(ErrorMessage = "Enter ContactNo2")]
        public string ContactNo2 { get; set; }
        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
    }
}