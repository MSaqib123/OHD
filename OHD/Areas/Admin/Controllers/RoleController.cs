using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OHD.Data;
using OHD.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IWebHostEnvironment iweb;

        //_________________________ 1 _____________________
        private readonly ODHContext context;
        private readonly UserManager<ApplicationUser> identityUser;
        private readonly SignInManager<ApplicationUser> identityManager;

        //_________________________ 2 _____________________
        private readonly RoleManager<IdentityRole> identityRole;

        public RoleController(UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb, RoleManager<IdentityRole> identityRole)
        {
            this.identityRole = identityRole;
            this.identityUser = identityUser;
            this.identityManager = identityManager;
            this.iweb = iweb;
        }
        
        public IActionResult Index()
        {
            //var list = context.Roles.ToList();
            var list = identityRole.Roles;
            return View(list);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([MinLength(2), Required] string name)
        {
            //ViewBag.roleList = new SelectList(roleManager.Roles,"Name","Id");
            if (ModelState.IsValid)
            {
                IdentityResult result = await identityRole.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
            }
            return View();
        }


        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await identityRole.FindByIdAsync(id);
            await identityRole.DeleteAsync(role);
            TempData["danger"] = "Role Deleted Success";
            return RedirectToAction("Index");
        }


        //public async Task<IActionResult> Edit(string id)
        //{
        //    IdentityRole role = await identityRole.FindByIdAsync(id);
        //    List<ApplicationUser> members = new List<ApplicationUser>();
        //    List<ApplicationUser> nonMembers = new List<ApplicationUser>();
        //    foreach (ApplicationUser user in identityUser.Users)
        //    {
        //        var list = await identityUser.IsInRoleAsync(user, role.Name) ? members : nonMembers;
        //        list.Add(user);
        //    }

        //    return View(new RoleEdit
        //    {
        //        Role = role,
        //        Members = members,
        //        NonMembers = nonMembers
        //    });
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(RoleEdit roleEdit)
        //{
        //    IdentityResult result;

        //    //___ addIds ____
        //    foreach (string userId in roleEdit.AddIds ?? new string[] { })
        //    {
        //        AppUser user = await identityRole.FindByIdAsync(userId);
        //        result = await identityRole.AddToRoleAsync(user, roleEdit.RoleName);
        //    }

        //    //___ addIds ____
        //    foreach (string userId in roleEdit.DeleteIds ?? new string[] { })
        //    {
        //        AppUser user = await userManager.FindByIdAsync(userId);
        //        result = await userManager.RemoveFromRoleAsync(user, roleEdit.RoleName);
        //    }

        //    return Redirect(Request.Headers["Referer"].ToString());

        //}



    }
}
