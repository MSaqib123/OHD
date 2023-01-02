using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OHD.Data;
using OHD.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OHD.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        
        //_________________________ 1 _____________________
        private readonly ODHContext context;
        private readonly UserManager<ApplicationUser> identityUserManager;
        private readonly SignInManager<ApplicationUser> identityManager;
        private readonly IWebHostEnvironment iWebHost;

        public UsersController(ODHContext context, UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb)
        {
            this.context = context;
            this.identityUserManager = identityUser;
            this.identityManager = identityManager;
            this.iWebHost = iweb;
        }

        public IActionResult Index()
        {
            var userList = context.Users.ToList();
            return View(userList);
        }

        public IActionResult Create(string? key)
        {
            ViewData["key"] = key;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(signupModel signUp)
        {
            if (ModelState.IsValid)
            {
                //_____ Check Email _________ (by Default hotaa ha Validate)
                var checkUser = await identityUserManager.FindByNameAsync(signUp.Email);
                if (checkUser == null)
                {
                    ViewBag.email = "Match";
                }
                else
                {
                    ViewBag.email = "Email Aready Exist";
                    return View();
                }

                var folder = "";
                if (signUp.iImage != null)
                {
                    folder = "Images/Users/";
                    folder += Guid.NewGuid().ToString() + "_" + signUp.iImage.FileName;
                    var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                    //model.iImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                    using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                    {
                        signUp.iImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                    }
                }

                var appUer = new ApplicationUser
                {
                    FirstName= signUp.FirstName,
                    LastNme = signUp.LastNme,
                    UserName = signUp.Email,
                    Email = signUp.Email,
                    Country = signUp.Country,
                    ProfileImage = folder
                };

                var result = await identityUserManager.CreateAsync(appUer, signUp.Password);

                if (result.Succeeded)
                {
                    await identityManager.SignInAsync(appUer, isPersistent: false);
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }



        public async Task<IActionResult> Edit(string id)
        {
            var user = await identityUserManager.FindByIdAsync(id);
            //var appUser = new ApplicationUser
            //{
            //    FirstName = user.FirstName,
            //    LastNme = user.LastNme,
            //    UserName = user.UserName,
            //    Email = user.Email,
            //    Country = user.Country,
            //    PasswordHash = user.PasswordHash,
            //    ProfileImage = user.ProfileImage
            //};
            return View(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(ApplicationUser model)
        {
            var updateUser = await identityUserManager.FindByIdAsync(model.Id);

            //____________ Image _________
            var folder = "";
            if (model.iImage != null)
            {
                //______ 1st Delete Current Image _____
                if (model.ProfileImage != null)
                {
                    var oldDirectory = Path.Combine(iWebHost.WebRootPath, model.ProfileImage);
                    if (System.IO.File.Exists(oldDirectory))
                    {
                        System.IO.File.Delete(oldDirectory);
                    }
                }

                folder = "Images/Users/";
                folder += Guid.NewGuid().ToString() + "_" + model.iImage.FileName;
                var serverFolder = Path.Combine(iWebHost.WebRootPath, folder);
                //model.iImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
                using (var fileMode = new FileStream(serverFolder, FileMode.Create))
                {
                    model.iImage.CopyTo(fileMode/*new FileStream(serverFolder, FileMode.Create)*/);
                }
                updateUser.ProfileImage = folder;
            }

            updateUser.FirstName = model.FirstName;
            updateUser.Country = model.Country;
            updateUser.Email = model.Email;
            updateUser.Country = model.Country;



            //_______ always unique ________ isaaa saa hum , update ,delete krtaa han
            //updateUser.UserName = model.UserName;

            var result = await identityUserManager.UpdateAsync(updateUser);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Users", new { area = "Admin" });
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            //context.Users.Update(model);
            //context.SaveChanges();
            return View(model);
        }


        public IActionResult delete(string id)
        {
            var user = context.Users.Where(x => x.Id == id).FirstOrDefault();
            if (user.ProfileImage != null)
            {
                var oldDirectory = Path.Combine(iWebHost.WebRootPath, user.ProfileImage);
                if (System.IO.File.Exists(oldDirectory))
                {
                    System.IO.File.Delete(oldDirectory);
                }
            }
            context.Users.Remove(user);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
