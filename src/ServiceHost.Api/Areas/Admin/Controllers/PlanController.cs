using IranCafe.Application.Contract.PlanAgg;
using IranCafe.Application.Contract.PlanAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class PlanController : AdminBaseController
    {
        private readonly IPlanApplication _planApplication;

        public PlanController(IPlanApplication planApplication) => _planApplication = planApplication;

        public async Task<IActionResult> Index() => View(await _planApplication.GetAll());

        public IActionResult Create() => PartialView("Create");

        [HttpPost]
        public async Task<IActionResult> Create(CreatePlanVM command)
        {
            var result = await _planApplication.Create(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        public async Task<IActionResult> Edit(Guid id) => PartialView("Edit", await _planApplication.GetDetailForEditBy(id));

        [HttpPost]
        public async Task<IActionResult> Edit(EditPlanVM command)
        {
            var result = await _planApplication.Edit(command);

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
            var result = await _planApplication.Delete(id);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }
    }
}