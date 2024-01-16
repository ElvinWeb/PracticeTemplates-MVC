using Hook.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Services.Service
{
    public interface IAccountService
    {
        Task Login(AdminLoginViewModel adminLoginViewModel);
        Task Logout();
    }
}
