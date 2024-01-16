using Hook.Business.Services.Service;
using Hook.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hook.UI.Areas.manage.Controllers
{
    [Area("manage")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            List<Setting> settingList = await _settingService.GetAllSettingAsync();

            return View(settingList);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Setting setting = await _settingService.GetSettingAsync(id);
            if (setting == null) return View("error");

            return View(setting);
        }
        public async Task<IActionResult> Update(Setting setting)
        {
            await _settingService.UpdateAsync(setting);


            return RedirectToAction("index", "setting");
        }
    }
}
