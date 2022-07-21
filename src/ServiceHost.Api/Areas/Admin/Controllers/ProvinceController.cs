using IranCafe.Application.Contract.SiteEntities.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Areas.Admin.Controllers
{
    public class ProvinceController : AdminBaseController
    {
        private readonly IProvinceApplication _provinceApplication;

        public ProvinceController(IProvinceApplication provinceApplication) => _provinceApplication = provinceApplication;

        public async Task<IActionResult> Index() => View(await _provinceApplication.GetAll());
        
    }
}
