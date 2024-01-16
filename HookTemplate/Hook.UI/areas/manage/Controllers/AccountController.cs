using Hook.Business.CustomExceptions.User;
using Hook.Business.Services.Service;
using Hook.Business.ViewModels;
using Hook.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hook.UI.areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(AdminLoginViewModel adminLoginViewModel)
        {
            if(!ModelState.IsValid) return View();
            try
            {
                await _accountService.Login(adminLoginViewModel);
            }
            catch (InvalidUsernameOrPasswordException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "feature");
        }

        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();

            return RedirectToAction("login", "account");
        }

        #region Admin create, role create , add role methods

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User admin = new User()
        //    {
        //        FullName = "Elvin Sarkarov",
        //        UserName = "AdminElvin",
        //    };

        //    var result = await _userManager.CreateAsync(admin, "@Admin1234");

        //    return Ok(result);
        //}

        //public async Task<IActionResult> CreateRoles()
        //{
        //    IdentityRole role1 = new IdentityRole("Admin");
        //    IdentityRole role2 = new IdentityRole("SuperAdmin");
        //    IdentityRole role3 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok("ok");
        //}

        //public async Task<IActionResult> AddRole()
        //{
        //    var admin = await _userManager.FindByNameAsync("AdminElvin");

        //    await _userManager.AddToRoleAsync(admin, "Admin");

        //    return Ok("ok");
        //}
        #endregion
    }
}
