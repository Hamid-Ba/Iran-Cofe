using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Application.Contract.SiteEntities.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class SettingController : AdminBaseController
    {
        private readonly ISettingApplication _settingApplication;

        public SettingController(ISettingApplication settingApplication) => _settingApplication = settingApplication;

        [HttpGet]
        public async Task<IActionResult> Modify() => View(await _settingApplication.GetSetting());


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modify(SettingDto command)
        {
            var result = await _settingApplication.Modify(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;
            else TempData[ErrorMessage] = result.Message;

            return RedirectToAction("Modify");
        }
    }
}