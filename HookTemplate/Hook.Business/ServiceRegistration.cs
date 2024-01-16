using Hook.Business.Services.Implementations;
using Hook.Business.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business
{
    public static class ServiceRegistration
    {
        public static void ServiceRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IAccountService, AccountService>();
            serviceDescriptors.AddScoped<IFeatureService, FeatureService>();
            serviceDescriptors.AddScoped<ISettingService, SettingService>();
        }
    }
}
