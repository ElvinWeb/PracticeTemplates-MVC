using Microsoft.AspNetCore.Mvc;
using NeoGym.Business.CustomException.General;
using NeoGym.Business.Services.Service;
using NeoGym.Core.Entities;

namespace NeoGym.UI.Areas.manage.Controllers
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
            if (id == null && id <= 0) return NotFound("id coludn't be null or negative");

            Setting setting = await _settingService.GetSettingByIdAsync(id);

            return View(setting);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Update(Setting setting)
        {
            if (!ModelState.IsValid) return View(setting);

            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (InvalidEntity ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index","setting");
        }
    }
}
