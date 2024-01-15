using BusinessTemplate.Business.CustomException.Blog;
using BusinessTemplate.Business.CustomException.Setting;
using BusinessTemplate.Business.Services.Service;
using BusinessTemplate.Core.Entities;
using BusinessTemplate.Core.Repositories;
using BusinessTemplate.Data.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace BusinessTemplate.Business.Services.Implementations
{
    public class SettingService : ISettingService
    {
        private readonly ISettingRepository _settingRepository;

        public SettingService(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public Task<List<Setting>> GetAllAsync()
        {
            return _settingRepository.GetAllAsync();
        }

        public Task<Setting> GetByIdAsync(int id)
        {
            return _settingRepository.GetByIdAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Setting setting)
        {
            Setting wantedSetting = await _settingRepository.GetByIdAsync(x => x.Id == setting.Id && !x.IsDeleted);

            if (wantedSetting == null) throw new SettingNullReferenceException("setting is null here!");

            wantedSetting.Value = setting.Value;

            await _settingRepository.CommitAsync();
        }
    }
}
