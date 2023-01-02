using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("identity_registor")]
    public partial class IdentityRegistor
    {
        public IdentityRegistor()
        {
            TblAssignbyAssignto = new HashSet<TblAssignbyAssignto>();
            TblComplaints = new HashSet<TblComplaints>();
        }

        [Key]
        [Column("identity_id")]
        public int IdentityId { get; set; }
        [Column("identity_name")]
        [StringLength(25)]
        public string IdentityName { get; set; }

        [InverseProperty("Assignto")]
        public virtual ICollection<TblAssignbyAssignto> TblAssignbyAssignto { get; set; }
        [InverseProperty("CompIdentity")]
        public virtual ICollection<TblComplaints> TblComplaints { get; set; }
    }
}
