using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AutoShop23.Models
{
    //We inherit from IdentityUser
    public class AppUser : IdentityUser
    {
        //add the properties
        [StringLength(20)]
        public string FirstName { get; set; }
        [StringLength(20)]
        public string LastName { get; set; }
    }
}
