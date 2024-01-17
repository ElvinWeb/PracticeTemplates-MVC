using Microsoft.Extensions.DependencyInjection;
using NeoGym.Business.Services.Implementations;
using NeoGym.Business.Services.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business
{
    public static class ServiceRegistration
    {
        public static void ServicesRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IAccountService, AccountService>();
            serviceDescriptors.AddScoped<ITrainerService, TrainerService>();
            serviceDescriptors.AddScoped<ISettingService, SettingService>();
        }
    }
}
