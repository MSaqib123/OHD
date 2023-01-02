using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OHD.Data;
using OHD.Models;
using System.Threading.Tasks;

namespace OHD.Areas.Account.Controllers
{
    [Area("Account")]
    public class AccountsController : Controller
    {
        private readonly IWebHostEnvironment iweb;
        private readonly UserManager<ApplicationUser> identityUser;
        private readonly SignInManager<ApplicationUser> identityManager;

        public AccountsController(UserManager<ApplicationUser> identityUser, SignInManager<ApplicationUser> identityManager, IWebHostEnvironment iweb)
        {
            this.identityUser = identityUser;
            this.identityManager = identityManager;
            this.iweb = iweb;
        }


        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(signupModel user)
        {
            if (ModelState.IsValid)
            {
                //_____ Check Email _________ (by Default hotaa ha Validate)
                var checkUser = await identityUser.FindByEmailAsync(user.Email);
                if (checkUser == null)
                {
                    ViewBag.email = "Match";
                }
                else
                {
                    ViewBag.email = "Email Aready Exist";
                    return View(user);
                }

                var appUer = new ApplicationUser
                {
                    FirstName = user.FirstName,
                    LastNme = user.LastNme,
                    UserName = user.Email,
                    Email = user.Email,
                };

                var result = await identityUser.CreateAsync(appUer, user.Password);


                if (result.Succeeded)
                {
                    await identityManager.SignInAsync(appUer, isPersistent: false);
                    return RedirectToAction("Index", "Home", new {area=""});
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }


        public async Task<IActionResult> Logout()
        {
            await identityManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" });
        }



        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await identityManager.PasswordSignInAsync(user.Email, user.Password, user.isRemember, lockoutOnFailure: false);

                if (result.Succeeded)
                {
                    //if(User.IsInRole("Admin") != null)
                    //{
                    //    return RedirectToAction("Index","Home");
                    //}
                    //else
                    return RedirectToAction("Index", "Home", new { id = "", Area = "" });
                    //}
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }
            }
            return View();
        }

    }
}
