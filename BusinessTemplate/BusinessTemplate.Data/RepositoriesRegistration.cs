using BusinessTemplate.Core.Repositories;
using BusinessTemplate.Data.Repositories.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Data
{
    public static class RepositoriesRegistration
    {
        public static void RepositoryRegistration(this IServiceCollection repositoryRegister)
        {
            repositoryRegister.AddScoped<IBlogRepository, BlogRepository>();
            repositoryRegister.AddScoped<ISettingRepository, SettingRepository>();
        }
    }
}
