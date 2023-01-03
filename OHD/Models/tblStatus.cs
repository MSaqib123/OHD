using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OHD.Models
{
    public class tblStatus
    {
        public tblStatus()
        {
            TblComplaints = new HashSet<TblComplaints>();
        }
        [Key]
        public int StId { get; set; }
        public string StName { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<TblComplaints> TblComplaints { get; set; }
    }
}
