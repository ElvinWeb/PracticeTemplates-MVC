using BusinessTemplate.Business.CustomException.Blog;
using BusinessTemplate.Business.CustomException.Setting;
using BusinessTemplate.Business.Services.Service;
using BusinessTemplate.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace BusinessTemplate.UI.Areas.manage.Controllers
{
    [Area("manage")]
    [Authorize(Roles = "Admin")]
    public class SettingController : Controller
    {
        private readonly ISettingService _settingService;

        public SettingController(ISettingService settingService)
        {
            _settingService = settingService;
        }
        public async Task<IActionResult> Index()
        {
            List<Setting> settingList = await _settingService.GetAllAsync();

            return View(settingList);
        }
        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            Setting setting = await _settingService.GetByIdAsync(id);

            if (setting == null) throw new SettingNullReferenceException("setting is null here!");

            return View(setting);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Setting setting)
        {
            if (!ModelState.IsValid) return View(setting);

            try
            {
                await _settingService.UpdateAsync(setting);
            }
            catch (SettingNullReferenceException ex)
            {
                ModelState.AddModelError(ex.PropertyName, ex.Message);
                return View();
            }

            return RedirectToAction("index", "setting");
        }
    }
}
