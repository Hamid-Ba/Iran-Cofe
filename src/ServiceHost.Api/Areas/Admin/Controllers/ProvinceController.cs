using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Application.Contract.SiteEntities.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class ProvinceController : AdminBaseController
    {
        private readonly IProvinceApplication _provinceApplication;

        public ProvinceController(IProvinceApplication provinceApplication) => _provinceApplication = provinceApplication;

        public async Task<IActionResult> Index() => View(await _provinceApplication.GetAll());

        [HttpGet]
        public IActionResult Create() => PartialView();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateProvinceDto command)
        {
            var result = await _provinceApplication.Create(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) => PartialView(await _provinceApplication.GetDetailForEditBy(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProvinceDto command)
        {
            var result = await _provinceApplication.Edit(command);

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
            var result = await _provinceApplication.Delete(id);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;
            return new JsonResult(result);
        }

    }
}