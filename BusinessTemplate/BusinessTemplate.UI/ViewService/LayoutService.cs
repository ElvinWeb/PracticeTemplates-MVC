using BusinessTemplate.Core.Entities;
using BusinessTemplate.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BusinessTemplate.UI.ViewService
{
    public class LayoutService
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public LayoutService(ISettingRepository settingRepository, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _settingRepository = settingRepository;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }

        public async Task<List<Setting>> GetSettings()
        {
            var settings = await _settingRepository.GetAllAsync();

            return settings;
        }
        public async Task<User> GetUser()
        {
            User admin = null;

            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                admin = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            }

            return admin;
        }

    }
}
