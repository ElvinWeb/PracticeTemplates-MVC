using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NeoGym.Business.CustomException.User;
using NeoGym.Business.Services.Service;
using NeoGym.Business.ViewModels;
using NeoGym.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.Services.Implementations
{
    [Area("manage")]
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

            admin = await _userManager.FindByNameAsync(adminLoginViewModel.UserName);
            if (admin == null) throw new InvalidUserCredential("", "Username or password is wrong!");

            var result = await _signInManager.PasswordSignInAsync(admin, adminLoginViewModel.Password, false, false);

            if (!result.Succeeded) throw new InvalidUserCredential("", "Username or password is wrong!");
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
