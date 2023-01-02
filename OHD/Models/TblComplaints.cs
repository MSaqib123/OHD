using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("tbl_complaints")]
    public partial class TblComplaints
    {
        [Key]
        [Column("comp_id")]
        public int CompId { get; set; }
        [Column("comp_name")]
        [StringLength(50)]
        public string CompName { get; set; }

        [Column("con_Number")]
        [StringLength(50)]
        public string ContactNumber { get; set; }

        [Column("Email_address")]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("Rasidance")]
        [StringLength(50)]
        public string Rasidance { get; set; }


        [Column("complain")]
        [StringLength(500)]
        public string BriefComplain { get; set; }


        [Column("comp_requestdate", TypeName = "date")]
        public DateTime? CompRequestdate { get; set; }
        [Column("comp_status")]
        public int? CompStatus { get; set; }


        //____________ Y runtime par ayy gee _____________
        [Column("comp_facilitySelected_Id")]
        public int? CompFacilitySelectedId { get; set; }
        [Column("comp_identity_id")]
        public int? CompIdentityId { get; set; }
        [Column("comp_assi_id")]
        public int? CompAssiId { get; set; }

        [ForeignKey(nameof(CompAssiId))]
        [InverseProperty(nameof(TblAssignees.TblComplaints))]
        public virtual TblAssignees CompAssi { get; set; }
        [ForeignKey(nameof(CompFacilitySelectedId))]
        [InverseProperty(nameof(TblFacilities.TblComplaints))]
        public virtual TblFacilities CompFacilitySelected { get; set; }
        [ForeignKey(nameof(CompIdentityId))]
        [InverseProperty(nameof(IdentityRegistor.TblComplaints))]
        public virtual IdentityRegistor CompIdentity { get; set; }
    }
}
