using NeoGym.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.Services.Service
{
    public interface ITrainerService
    {
        Task UpdateAsync(Trainer trainer);
        Task CreateAsync(Trainer trainer);
        Task DeleteAsync(int id);
        Task SoftDelete(int id);
        Task<List<Trainer>> GetAllTrainerAsync();
        Task<Trainer> GetTrainerByIdAsync(int id);
    }
}
