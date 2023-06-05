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
                

                //try
                //{
                //    await _seedService.SeedRoles();
                //    var roleName = "user";

                //    if (!await _userManager.Users.AnyAsync())
                //        roleName = "admin";

                //    IdentityUser identityUser = model;
                //    await _userManager.CreateAsync(identityUser, model.Password);
                //    await _userManager.AddToRoleAsync(identityUser, roleName);

                //    UserProfileEntity userProfileEntity = model;
                //    userProfileEntity.UserId = identityUser.Id;

                //    _identityContext.UserProfiles.Add(userProfileEntity);
                //    await _identityContext.SaveChangesAsync();

                //    return true;
                //}
                //catch { return false; }
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

//gmail: sharmaranjan.dev@gmail.com





        //UserRepository _userRepository;

        //[HttpGet]
        //public ActionResult RegisterUser() //FORM
        //{
        //    CountryRepository DBcountry = new CountryRepository();
        //    List<Country> countries = DBcountry.GetCountries();

        //    ViewBag.countries = countries;

        //    return View();
        //}
        //[HttpPost]
        //public ActionResult RegisterUser(UserViewModel userWM) //SAVE THE INFO FROM FORM
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _userRepository = new UserRepository();
        //        UserRepository userToDB = _userRepository;
        //        User userData = new User();
        //        userData.Firstname = userWM.Firstname;
        //        userData.Lastname = userWM.Lastname;
        //        userData.Email = userWM.Email;
        //        userData.Password = userWM.Password;
        //        userData.CountryID = userWM.CountryID;
        //        //userData.Image = userWM.Photo;
        //        bool returnUser = userToDB.SaveUser(userData);
        //    }
        //    else
        //    {
        //        //This line will fetch errors and assign it to errorMessages
        //        IEnumerable<string> errorMessages = ModelState.Values.SelectMany(V => V.Errors).Select(e => e.ErrorMessage);
        //        ViewBag.Errors = errorMessages;
        //    }


        //    CountryRepository DBcountry = new CountryRepository();
        //    IEnumerable<Country> countries = DBcountry.GetCountries();

        //    ViewBag.countries = countries;

        //    return View();
        //}