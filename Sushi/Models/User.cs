using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sushi.Models
{
    //[Index(nameof(User.Login), nameof(User.PhoneNum), IsUnique = true)]
    public class User:IdentityUser
    {
     
        public string SafeWord { get; set; }
    }
}
