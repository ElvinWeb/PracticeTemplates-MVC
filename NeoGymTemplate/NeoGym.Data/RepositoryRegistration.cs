using Microsoft.Extensions.DependencyInjection;
using NeoGym.Core.Repositories;
using NeoGym.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Data
{
    public static class RepositoryRegistration
    {
        public static void RepositoriesRegister(this IServiceCollection serviceDescriptors)
        {
            serviceDescriptors.AddScoped<ISettingRepository, SettingRepository>();
            serviceDescriptors.AddScoped<ITrainerRepository, TrainerRepository>();
        } 
    }
}
