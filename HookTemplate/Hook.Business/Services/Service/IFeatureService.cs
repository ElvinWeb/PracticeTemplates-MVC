using Hook.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Services.Service
{
    public interface IFeatureService
    {
        Task CreateAsync(Feature feature);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task UpdateAsync(Feature feature);
        Task<Feature> GetFeatureAsync(int id);
        Task<List<Feature>> GetAllFeatureAsync();
    }
}
