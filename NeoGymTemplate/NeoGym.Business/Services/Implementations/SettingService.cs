using NeoGym.Business.CustomException.General;
using NeoGym.Business.Services.Service;
using NeoGym.Core.Entities;
using NeoGym.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeoGym.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<List<Setting>> GetAllSettingAsync()
        {
            return await _settingRepository.GetAllAsync(x => !x.IsDeleted);
        }

        public async Task<Setting> GetSettingByIdAsync(int id)
        {
            return await _settingRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateAsync(Setting setting)
        {
            Setting wantedSetting = await _settingRepository.GetByIdAsync(x => x.Id == setting.Id && !x.IsDeleted);
            if (wantedSetting == null) throw new InvalidEntity("entity is null here!");

            wantedSetting.Value = setting.Value;

            await _settingRepository.SaveAsync();
        }
    }
}
