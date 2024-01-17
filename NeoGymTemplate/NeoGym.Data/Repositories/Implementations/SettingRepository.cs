using NeoGym.Core.Entities;
using NeoGym.Core.Repositories;
using NeoGym.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Data.Repositories.Implementations
{
    public class SettingRepository : GenericRepository<Setting>, ISettingRepository
    {
        public SettingRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
