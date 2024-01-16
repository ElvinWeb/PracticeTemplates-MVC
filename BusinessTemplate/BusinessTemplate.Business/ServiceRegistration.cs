using BusinessTemplate.Business.Services.Implementations;
using BusinessTemplate.Business.Services.Service;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business
{
    public static class ServiceRegistration
    {
        public static void ServicesRegistration(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<IAccountService, AccountService>();
            serviceDescriptors.AddScoped<IBlogService, BlogService>();
            serviceDescriptors.AddScoped<ISettingService, SettingService>();
        }
    }
}
