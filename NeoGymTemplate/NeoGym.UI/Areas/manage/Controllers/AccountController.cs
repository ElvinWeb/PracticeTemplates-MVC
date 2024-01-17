using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeoGym.Business.CustomException.User;
using NeoGym.Business.Services.Service;
using NeoGym.Business.ViewModels;
using NeoGym.Core.Entities;

namespace NeoGym.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IAccountService accountService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
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
            if (!ModelState.IsValid) return View(adminLoginViewModel);

            try
            {
                await _accountService.Login(adminLoginViewModel);
            }
            catch (InvalidUserCredential ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "trainer");
        }


        public async Task<IActionResult> CreateAdmin()
        {
            User admin = new User()
            {
                FullName = "Elvin Sarkarov",
                UserName = "Admin1"
            };

            var result = await _userManager.CreateAsync(admin, "@Admin1234");

            return Ok(result);
        }
        public async Task<IActionResult> CreateRoles()
        {
            IdentityRole role1 = new IdentityRole("Admin");
            IdentityRole role2 = new IdentityRole("User");
            IdentityRole role3 = new IdentityRole("SuperAdmin");

            await _roleManager.CreateAsync(role1);
            await _roleManager.CreateAsync(role2);
            await _roleManager.CreateAsync(role3);

            return Ok("oldu");
        }
        public async Task<IActionResult> AddRole()
        {
            User admin = await _userManager.FindByNameAsync("Admin1");
            await _userManager.AddToRoleAsync(admin, "Admin");

            return Ok("rol elave edildi");
        }
    }
}
