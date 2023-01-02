using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace OHD.Models
{
    [Table("tbl_facilities")]
    public partial class TblFacilities
    {
        public TblFacilities()
        {
            TblComplaints = new HashSet<TblComplaints>();
            TblLab = new HashSet<TblLab>();
            TblFacilityImages = new HashSet<TblFacilityImages>();
        }

        [Key]
        [Column("faci_id")]
        public int FaciId { get; set; }


        [Column("faci_facilities")]
        [StringLength(25)]
        public string FaciFacilities { get; set; }


        [Column("faci_Image")]
        [StringLength(250)]
        public string FaciImage { get; set; }


        [Column("faci_brifedescription")]
        [StringLength(1200)]
        public string FaciBrifedescription { get; set; }


        [NotMapped]
        public IFormFile MainBrowsImage { get; set; }


        [InverseProperty("CompFacilitySelected")]
        public virtual ICollection<TblComplaints> TblComplaints { get; set; }

        [InverseProperty("LabFacility")]
        public virtual ICollection<TblLab> TblLab { get; set; }

        [InverseProperty("tblFacility")]
        public virtual ICollection<TblFacilityImages> TblFacilityImages { get; set; }
    }
}
