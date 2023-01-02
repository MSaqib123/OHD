using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD.Models
{
    [Table("tbl_multipleFacilityImages")]
    public class TblFacilityImages
    {
        [Key]
        [Column("multiImage_id")]
        public int Id { get; set; }
        [Column("facilityImages")]
        public string ImageUrl { get; set; }


        [Column("faci_id")]
        public int? FaciId { get; set; }

        [ForeignKey(nameof(FaciId))]
        [InverseProperty(nameof(TblFacilities.TblFacilityImages))]
        public virtual TblFacilities tblFacility{ get; set; }

    }
}
