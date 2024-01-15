using BusinessTemplate.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.Services.Service
{
    public interface IAccountService
    {
        Task Login(LoginViewModel loginViewModel);
        Task Logout();
    }
}
