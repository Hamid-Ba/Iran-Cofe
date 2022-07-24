using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Mvc;
using Framework.Domain.Cafe;
using IranCafe.Application.Contract.CafeAgg;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class CafeController : AdminBaseController
    {
        private readonly ICafeApplication _cafeApplication;

        public CafeController(ICafeApplication cafeApplication) => _cafeApplication = cafeApplication;

        public async Task<IActionResult> FilterCafes(CafeStatus status)
        {
            ViewBag.Status = status;
            return View(await _cafeApplication.GetAllBy(status));
        }

        [HttpGet]
        public IActionResult Confirm(Guid id) => PartialView("Confirm", new ChangeCafeStatusDto() { Id = id });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Confirm(ChangeCafeStatusDto command)
        {
            command.Status = CafeStatus.Confirmed;
            var result = await _cafeApplication.ChangeStatus(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

        [HttpGet]
        public IActionResult DissConfirm(Guid id) => PartialView("DissConfirm", new ChangeCafeStatusDto() { Id = id });

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> DissConfirm(ChangeCafeStatusDto command)
        {
            command.Status = CafeStatus.Reject;

            var result = await _cafeApplication.ChangeStatus(command);

            if (result.IsSucceeded) TempData[SuccessMessage] = result.Message;

            return new JsonResult(result);
        }

    }
}