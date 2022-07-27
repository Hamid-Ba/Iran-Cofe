using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class CategoryController : AdminBaseController
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication) => _categoryApplication = categoryApplication;

        public async Task<IActionResult> Index() => View(await _categoryApplication.GetAllBy());

        [HttpGet]
        public IActionResult Create() => PartialView();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryDto command)
        {
            var result = await _categoryApplication.Create(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) => PartialView(await _categoryApplication.GetDetailForEditBy(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditCategoryDto command)
        {
            var result = await _categoryApplication.Edit(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }
    }
}
