using Microsoft.AspNetCore.Http;
using OHD.Models;
using System.Collections.Generic;

namespace OHD.Data.ViewModels
{
    public class VMcomplainfacility
    {
        public TblFacilities tbl_facility { get; set; }
        public TblComplaints tbl_Complain{ get; set; }

        ////___________ List of Record ____________
        //public IEnumerable<TblFacilities> tblFacility_List { get; set; }
        //public IEnumerable<TblFacilityImages> tblFacilityImages_List { get; set; }


        ////___________ Mutliple Images File ____________
        //public List<IFormFile> Images { get; set; }
    }
}
