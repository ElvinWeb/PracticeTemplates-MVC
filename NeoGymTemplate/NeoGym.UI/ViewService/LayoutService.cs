using Microsoft.AspNetCore.Identity;
using NeoGym.Business.Services.Service;
using NeoGym.Core.Entities;

namespace NeoGym.UI.ViewService
{
    public class LayoutService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISettingService _settingService;
        private readonly UserManager<User> _userManager;

        public LayoutService(IHttpContextAccessor httpContextAccessor, ISettingService settingService, UserManager<User> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _settingService = settingService;
            _userManager = userManager;
        }

        public async Task<List<Setting>> GetSettings()
        {
            var settings = await _settingService.GetAllSettingAsync();

            return settings;
        }

        public async Task<User> GetAdmin()
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
