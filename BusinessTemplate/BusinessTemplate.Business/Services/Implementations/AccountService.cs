using BusinessTemplate.Business.CustomException.User;
using BusinessTemplate.Business.Services.Service;
using BusinessTemplate.Business.ViewModels;
using BusinessTemplate.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.Services.Implementations
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
        public async Task Login(LoginViewModel loginViewModel)
        {
            User admin = null;

            admin = await _userManager.FindByNameAsync(loginViewModel.UserName);

            if (admin == null) throw new InvalidUsernameOrPasswordException("", "username or password is wrong!");

            var result = await _signInManager.PasswordSignInAsync(admin, loginViewModel.Password, false, false);

            if (!result.Succeeded) throw new InvalidUsernameOrPasswordException("", "username or password is wrong!");

        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
