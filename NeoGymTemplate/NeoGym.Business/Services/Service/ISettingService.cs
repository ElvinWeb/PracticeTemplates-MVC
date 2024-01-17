using NeoGym.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.Services.Service
{
    public interface ISettingService
    {
        Task<List<Setting>> GetAllSettingAsync();
        Task<Setting> GetSettingByIdAsync(int id);
        Task UpdateAsync(Setting setting);
    }
}
