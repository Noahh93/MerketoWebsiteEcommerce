using Microsoft.AspNetCore.Mvc;
using AssignmentMVC.Models;
using AssignmentMVC.Repositories;
using AssignmentMVC.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace AssignmentMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public ActionResult RegisterUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if(ModelState.IsValid)
            {
                AppUser appUser = new AppUser();
                appUser.Firstname = model.FirstName;
                appUser.Lastname = model.LastName;
                appUser.Email = model.Email;
                appUser.UserName = model.Email;
                appUser.Password = model.Password;
                appUser.StreetName = model.StreetName;
                appUser.PostalCode = model.PostalCode;
                appUser.City = model.City;
                string roleName = "user";
                if (_userManager.Users.Count() == 0)
                {
                    roleName = "admin";

                }
                var roleExists = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExists)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }


                var result = await _userManager.CreateAsync(appUser, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(appUser, roleName);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ViewBag.RegisterFail = "User was not registered";
                }
                
            }
            return View();

        }

        [HttpGet] //Not neccessary to write this line
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(LoginViewModel loginVM)
        {

           
            var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password, true, false);
            //return result.Succeeded;
            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Incorrect = "Incorrect email or password";
            }
            
            return View();
        }
        
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            

            return RedirectToAction("Login","Account");
        }
    }

}
