using Hook.Core.Repositories;
using Hook.Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Data
{
    public static class RepositoryRegistration
    {
        public static void RepositoryRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ISettingRepository, SettingRepository>();
            serviceDescriptors.AddScoped<IFeatureRepository, FeatureRepository>();
        }
    }
}
