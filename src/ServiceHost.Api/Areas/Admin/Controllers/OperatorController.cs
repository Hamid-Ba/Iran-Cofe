using IranCafe.Application.Contract.AccountAgg;
using IranCafe.Application.Contract.AccountAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class OperatorController : AdminBaseController
    {
        private readonly IOperatorApplication _operatorApplication;

        public OperatorController(IOperatorApplication operatorApplication) => _operatorApplication = operatorApplication;

        public async Task<IActionResult> Index() => View(await _operatorApplication.GetAll());

        [HttpGet]
        public IActionResult Create() => PartialView("Create");

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOperatorDto command)
        {
            var result = await _operatorApplication.Create(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;
            return new JsonResult(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) => PartialView(await _operatorApplication.GetDetailForEditBy(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditOperatorDto command)
        {
            var result = await _operatorApplication.Edit(command);

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
            var result = await _operatorApplication.Delete(id);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;
            return new JsonResult(result);
        }
    }
}