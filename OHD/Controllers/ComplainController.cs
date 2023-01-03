using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OHD.Data;
using OHD.Data.ViewModels;
using OHD.Models;
using System.Linq;
using System.Threading.Tasks;

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
        
        //_________________ 1st Complian kraa ga ____________
        public IActionResult DoComplain(int id)
        {
            VMcomplainfacility vm = new VMcomplainfacility();
            vm.tbl_Complain = new TblComplaints();
            vm.tbl_facility = context.TblFacilities.Where(x=>x.FaciId == id).FirstOrDefault();
            vm.tblFacilityImages_List = context.TblFacilityImages.Where(x => x.FaciId == 1).ToList();
            return View(vm);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DoComplain(VMcomplainfacility vm)
        {
            ApplicationUser usr = await identityUserManager.GetUserAsync(HttpContext.User);
            vm.tbl_Complain.userId = usr.Id;
            vm.tbl_Complain.CompStatusId = 1; //pending
            vm.tbl_Complain.CompFacilitySelectedId = vm.tbl_facility.FaciId;

            await context.TblComplaints.AddAsync(vm.tbl_Complain);
            await  context.SaveChangesAsync();
            return RedirectToAction("Index","Home");
        }


        //_________________ 2nd Record Check kraa gaa _______________
        [Authorize]
        public async Task<IActionResult> Index()
        {
            ApplicationUser usr = await identityUserManager.GetUserAsync(HttpContext.User);
            var list = context.TblComplaints.Include(x => x.Status).Include(x => x.User).Where(x=>x.userId == usr.Id).ToList();
            return View(list);
        }

        
    }
}
