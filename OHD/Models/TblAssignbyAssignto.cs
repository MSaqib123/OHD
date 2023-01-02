using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("tbl_assignby_assignto")]
    public partial class TblAssignbyAssignto
    {
        [Key]
        [Column("by_to_id")]
        public int ByToId { get; set; }
        [Column("assignby_id")]
        public int? AssignbyId { get; set; }
        [Column("assignto_id")]
        public int? AssigntoId { get; set; }
        [Column("assigny_date", TypeName = "date")]
        public DateTime? AssignyDate { get; set; }

        [ForeignKey(nameof(AssignbyId))]
        [InverseProperty(nameof(TblAssignees.TblAssignbyAssignto))]
        public virtual TblAssignees Assignby { get; set; }
        [ForeignKey(nameof(AssigntoId))]
        [InverseProperty(nameof(IdentityRegistor.TblAssignbyAssignto))]
        public virtual IdentityRegistor Assignto { get; set; }
    }
}
