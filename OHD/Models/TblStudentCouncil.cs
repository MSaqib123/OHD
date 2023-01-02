using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("tbl_student_council")]
    public partial class TblStudentCouncil
    {
        [Key]
        [Column("stu_cons_id")]
        public int StuConsId { get; set; }
        [Column("stu_cons_name")]
        [StringLength(30)]
        public string StuConsName { get; set; }
        [Column("stu_maintanies_id")]
        public int? StuMaintaniesId { get; set; }

        [ForeignKey(nameof(StuMaintaniesId))]
        [InverseProperty(nameof(TblMaintaines.TblStudentCouncil))]
        public virtual TblMaintaines StuMaintanies { get; set; }
    }
}
