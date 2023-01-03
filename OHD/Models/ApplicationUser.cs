using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            TblComplaints = new HashSet<TblComplaints>();
        }

        public string FirstName { get; set; }
        public string LastNme { get; set; }

        public string? Country { get; set; }
        public string? ProfileImage { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int? Age { get; set; }

        [NotMapped]
        public IFormFile iImage { get; set; }


        [InverseProperty("User")]
        public virtual ICollection<TblComplaints> TblComplaints { get; set; }
    }
}
