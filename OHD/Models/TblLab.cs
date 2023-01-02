using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("tbl_lab")]
    public partial class TblLab
    {
        public TblLab()
        {
            TblMaintaines = new HashSet<TblMaintaines>();
        }

        [Key]
        [Column("lab_id")]
        public int LabId { get; set; }
        [Column("lab_name")]
        [StringLength(30)]
        public string LabName { get; set; }
        [Column("lab_descirption")]
        [StringLength(500)]
        public string LabDescirption { get; set; }
        [Column("lab_facility_id")]
        public int? LabFacilityId { get; set; }

        [ForeignKey(nameof(LabFacilityId))]
        [InverseProperty(nameof(TblFacilities.TblLab))]
        public virtual TblFacilities LabFacility { get; set; }
        [InverseProperty("MaintLab")]
        public virtual ICollection<TblMaintaines> TblMaintaines { get; set; }
    }
}
