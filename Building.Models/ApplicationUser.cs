using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;


namespace Building.Models
{
    public  class ApplicationUser: IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public string? PostalCode { get; set; }
        //public string PasswordHash { get; set; }
        //public string UserName { get; set; }
        //public string NormalizedUserName { get; set; }
        //public string NormalizedEmail { get; set; }
        //public DateTime CreatedDate { get; set; }
        //public DateTime LastLoginDate { get; set; }
    }

}
