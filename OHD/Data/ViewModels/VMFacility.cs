using Microsoft.AspNetCore.Http;
using OHD.Models;
using System.Collections.Generic;

namespace OHD.Data.ViewModels
{
    public class VMFacility
    {
        public TblFacilities tblFacility{ get; set; }
        public TblFacilityImages tblFacilityImages { get; set; }

        //___________ List of Record ____________
        public IEnumerable<TblFacilities> tblFacility_List { get; set; }
        public IEnumerable<TblFacilityImages> tblFacilityImages_List { get; set; }


        //___________ Mutliple Images File ____________
        public List<IFormFile> Images{ get; set; }
    }
}
