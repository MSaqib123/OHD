using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("tbl_assignees")]
    public partial class TblAssignees
    {
        public TblAssignees()
        {
            TblAssignbyAssignto = new HashSet<TblAssignbyAssignto>();
            TblComplaints = new HashSet<TblComplaints>();
        }

        [Key]
        [Column("assi_id")]
        public int AssiId { get; set; }
        [Column("assi_name")]
        [StringLength(30)]
        public string AssiName { get; set; }

        [InverseProperty("Assignby")]
        public virtual ICollection<TblAssignbyAssignto> TblAssignbyAssignto { get; set; }
        [InverseProperty("CompAssi")]
        public virtual ICollection<TblComplaints> TblComplaints { get; set; }
    }
}
