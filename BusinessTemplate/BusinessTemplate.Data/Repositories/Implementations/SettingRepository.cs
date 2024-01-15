using BusinessTemplate.Core.Entities;
using BusinessTemplate.Core.Repositories;
using BusinessTemplate.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Data.Repositories.Implementations
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
