using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OHD.Data;
using OHD.Data.ViewModels;
using OHD.Models;
using System.Linq;
using System.Threading.Tasks;

namespace OHD.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserComplainsController : Controller
    {
        //_________________________ 1 _____________________
        private readonly ODHContext context;
        private readonly UserManager<ApplicationUser> identityUserManager;
        private readonly SignInManager<ApplicationUser> identityManager;
        private readonly IWebHostEnvironment iWebHost;


        public UserComplainsController(ODHContext context, UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb)
        {
            this.context = context;
            this.identityUserManager = identityUser;
            this.identityManager = identityManager;
            this.iWebHost = iweb;
        }


        public IActionResult Index(int status = 0)
        {
            var list = context.TblComplaints.Include(x=>x.Status).Include(x=>x.User).ToList();
            if (status == 1)
            {
                var st1 = status;
                var st2 = status + 1;
                list = context.TblComplaints.Include(x => x.Status).Include(x => x.User).Where(x=>x.CompStatusId == st1 || x.CompStatusId == st2).ToList();
                ViewBag.vg = "UnCompleted Complains";
            }
            else if(status == 3)
            {
                list = context.TblComplaints.Include(x => x.Status).Include(x => x.User).Where(x => x.CompStatusId == 3).ToList();
                ViewBag.vg = "Completed Complains";
            }
            return View(list);
        }

        public IActionResult Edit(int id)
        {
            ViewBag.Status = new SelectList(context.tblStatus.ToList(), "StId", "StName");
            var selectedRecord = context.TblComplaints.Where(x => x.CompId== id).FirstOrDefault();
            return View(selectedRecord);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(TblComplaints model)
        {
            ViewBag.Status = new SelectList(context.tblStatus.ToList(), "StId", "StName");
            context.TblComplaints.Update(model);
            context.SaveChanges();
            return RedirectToAction("Index", "UserComplains", new { area="Admin"});
        }

        public IActionResult delete(string id)
        {
            var user = context.TblComplaints.Find(id);
            context.TblComplaints.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
