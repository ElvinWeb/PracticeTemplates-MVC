using BusinessTemplate.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.Services.Service
{
    public interface IBlogService
    {
        Task CreateAsync(Blog blog);
        Task UpdateAsync(Blog blog);
        Task DeleteAsync(int id);
        Task<Blog> GetByIdAsync(int id);
        Task<List<Blog>> GetAllAsync();
        Task SoftDelete(int id);
    }
}
