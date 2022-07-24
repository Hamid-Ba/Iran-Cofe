using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Mvc;
using Framework.Domain.Cafe;

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

    }
}