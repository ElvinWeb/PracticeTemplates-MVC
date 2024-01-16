using Hook.Business.Services.Service;
using Hook.Core.Entities;
using Hook.Core.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Hook.UI.ViewService
{
    public class LayoutService
    {
        private readonly ISettingService _settingService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        public LayoutService(ISettingService settingService, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            _settingService = settingService;
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;

        }

        public async Task<List<Setting>> GetSettings()
        {
            var settings = await _settingService.GetAllSettingAsync();

            return settings;
        }

        public async Task<User> GetUser()
        {
            User admin = null;
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                admin = await _userManager.FindByNameAsync(_httpContextAccessor.HttpContext.User.Identity.Name);
            };

            return admin;
        }
    }
}
