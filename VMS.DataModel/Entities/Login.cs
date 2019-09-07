using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VMS.DataModel.Entities
{
    public class Login
    {
        [Required]
        public string userName { get; set; }
        [Required]
        public string password { get; set; }
    }
}
