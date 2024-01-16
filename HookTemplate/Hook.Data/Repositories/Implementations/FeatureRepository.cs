using Hook.Core.Entities;
using Hook.Core.Repositories;
using Hook.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Data.Repositories.Implementations
{
    public class FeatureRepository : GenericRepository<Feature>, IFeatureRepository
    {
        public FeatureRepository(HookDbContext context) : base(context)
        {
        }
    }
}
