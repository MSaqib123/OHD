using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OHD.Data;
using OHD.Data.ViewModels;
using OHD.Models;
using System.Linq;

namespace OHD.Controllers
{
    public class ComplainController : Controller
    {
        //_________________________ 1 _____________________
        private readonly ODHContext context;
        private readonly UserManager<ApplicationUser> identityUserManager;
        private readonly SignInManager<ApplicationUser> identityManager;
        private readonly IWebHostEnvironment iWebHost;

        public ComplainController(ODHContext context, UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb)
        {
            this.context = context;
            this.identityUserManager = identityUser;
            this.identityManager = identityManager;
            this.iWebHost = iweb;
        }
        
        public IActionResult DoComplain(int id)
        {
            VMcomplainfacility vm = new VMcomplainfacility();
            vm.tbl_Complain = new TblComplaints();
            vm.tbl_facility = context.TblFacilities.Where(x=>x.FaciId == id).FirstOrDefault();
            return View(vm);
        }
        public IActionResult DoComplain(VMcomplainfacility vm)
        {
            vm.tbl_Complain.CompIdentityId = vm.tbl_facility.FaciId;
            vm.tbl_Complain.CompStatus = 1; //pending
            vm.tbl_Complain.CompFacilitySelectedId = vm.tbl_facility.FaciId;

            context.TblComplaints.Add(vm.tbl_Complain);
            context.SaveChanges();
            return RedirectToAction("Index","Home");
        }
    }
}
