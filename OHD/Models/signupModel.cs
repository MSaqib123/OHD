using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD.Models
{
    public class signupModel
    {
        public string FirstName { get; set; }
        public string LastNme { get; set; }

        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]

        public string ConPassword { get; set; }

        //___________ 7. AFter Adding Column in ===> IdentityUser _______________________
        public string? Country { get; set; }
        public string? profileImage { get; set; }

        [NotMapped]
        public IFormFile iImage { get; set; }
    }
}
