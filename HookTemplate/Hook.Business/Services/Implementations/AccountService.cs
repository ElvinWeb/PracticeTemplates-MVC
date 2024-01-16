using Hook.Business.CustomExceptions.User;
using Hook.Business.Services.Service;
using Hook.Business.ViewModels;
using Hook.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountService(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task Login(AdminLoginViewModel adminLoginViewModel)
        {
            User admin = null;

            admin = await _userManager.FindByNameAsync(adminLoginViewModel.Username);

            if (admin == null) throw new InvalidUsernameOrPasswordException("", "Username or Password is wrong!");

            var result = await _signInManager.PasswordSignInAsync(admin, adminLoginViewModel.Password, false, false);

            if (!result.Succeeded) throw new InvalidUsernameOrPasswordException("", "Username or Password is wrong!");

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
