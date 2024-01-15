using BusinessTemplate.Business.CustomException.User;
using BusinessTemplate.Business.Services.Service;
using BusinessTemplate.Business.ViewModels;
using BusinessTemplate.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace BusinessTemplate.UI.Areas.manage.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid) return View();

            try
            {
                await _accountService.Login(loginViewModel);
            }
            catch (InvalidUsernameOrPasswordException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "blog");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();

            return RedirectToAction("index", "blog");
        }

        #region Admin operations

        //public async Task<IActionResult> CreateAdmin()
        //{
        //    User admin = new User()
        //    {
        //        FullName = "Elvin Sarkarov",
        //        UserName = "Admin1"
        //    };

        //    var result = await _userManager.CreateAsync(admin, "#Admin1234");

        //    return Ok(result);
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role1 = new IdentityRole("Admin");
        //    IdentityRole role2 = new IdentityRole("SuperAdmin");
        //    IdentityRole role3 = new IdentityRole("Member");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok("rollar yarandi");
        //}
        //public async Task<IActionResult> AddRoleToAdmin()
        //{
        //    var admin = await _userManager.FindByNameAsync("Admin1");

        //    await _userManager.AddToRoleAsync(admin, "Admin");

        //    return Ok("rol elave edildi");
        //}
        #endregion
    }
}
