using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sushi.Models
{
    public class RegisterViewModel:IdentityUser
    {
        
        [Required]
        [EmailAddress]
        [Remote("EmailIsUnique", "User", ErrorMessage = "User with this email exist.")]
        public override string Email { get; set; }

        
        [Required]
        [DisplayName("Phone Number")]
        [Phone]
        [Remote("PhoneNumIsUnique", "User", ErrorMessage = "User with this phone number exist.")]
        public override string PhoneNumber { get; set; }
        [Required]
        [DisplayName("User Name")]
        [Phone]
        [Remote("NameIsUnique", "User", ErrorMessage = "User with this name exist.")]
        public override string UserName { get; set; }

        [Required]
        [DisplayName("Safe word")]
        public string SafeWord { get; set; }

        [Required]
        [DataType(DataType.Password)]
        
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    
    }
}
