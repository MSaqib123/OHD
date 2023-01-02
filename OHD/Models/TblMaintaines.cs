using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("tbl_maintaines")]
    public partial class TblMaintaines
    {
        public TblMaintaines()
        {
            TblStudentCouncil = new HashSet<TblStudentCouncil>();
        }

        [Key]
        [Column("maint_id")]
        public int MaintId { get; set; }
        [Column("maint_lab_id")]
        public int? MaintLabId { get; set; }
        [Column("maint_status")]
        public int? MaintStatus { get; set; }

        [ForeignKey(nameof(MaintLabId))]
        [InverseProperty(nameof(TblLab.TblMaintaines))]
        public virtual TblLab MaintLab { get; set; }
        [InverseProperty("StuMaintanies")]
        public virtual ICollection<TblStudentCouncil> TblStudentCouncil { get; set; }
    }
}
