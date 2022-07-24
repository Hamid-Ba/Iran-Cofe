using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Application.Contract.SiteEntities.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class CityController : AdminBaseController
    {
        private readonly ICityApplication _cityApplication;

        public CityController(ICityApplication cityApplication) => _cityApplication = cityApplication;

        public async Task<IActionResult> Index(Guid provinceId) => View(await _cityApplication.GetAllBy(provinceId));

        [HttpGet]
        public IActionResult Create(Guid provinceId) => PartialView(new CreateCityDto { ProvinceId = provinceId });

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCityDto command)
        {
            var result = await _cityApplication.Create(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) => PartialView(await _cityApplication.GetDetailForEditBy(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCityDto command)
        {
            var result = await _cityApplication.Edit(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult Delete(Guid id) => PartialView(id);

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PostDelete(Guid id)
        {
            var result = await _cityApplication.Delete(id);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;
            return new JsonResult(result);
        }
    }
}