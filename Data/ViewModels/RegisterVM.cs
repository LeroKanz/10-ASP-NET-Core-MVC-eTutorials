using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eTutorials.Data.ViewModels
{
    public class RegisterVM
    {
        [Display(Name = "Full Name")]
        [Required (ErrorMessage = "Full Name is requared!")]
        public string FullName { get; set; }

        [Display(Name = "your Email")]
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirmed Password")]
        [Required(ErrorMessage = "Confirme Password is requared!")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
