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
    public class BlogRepository : GenericRepository<Blog>, IBlogRepository
    {
        public BlogRepository(ProjectDbContext context) : base(context)
        {
        }
    }
}
