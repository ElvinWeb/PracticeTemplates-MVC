using Hook.Business.CustomExceptions.General;
using Hook.Business.Services.Service;
using Hook.Core.Entities;
using Hook.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hook.Business.Services.Implementations
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

        public async Task<Setting> GetSettingAsync(int id)
        {
            return await _settingRepository.GetByIdAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task UpdateAsync(Setting setting)
        {
            Setting wantedSetting = await _settingRepository.GetByIdAsync(x => x.Id == setting.Id && !x.IsDeleted);
            if (wantedSetting == null) throw new EntityNullReferenceException("setting is null here!");

            wantedSetting.Value = setting.Value;
            wantedSetting.UpdatedDate = DateTime.UtcNow.AddHours(4);

            await _settingRepository.SaveAsync();
        }
    }
}
