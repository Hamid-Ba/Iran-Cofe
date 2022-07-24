using IranCafe.Application.Contract.SiteEntities.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class ProvinceController : BaseApiController
    {
        private readonly IProvinceApplication _provinceApplication;

        public ProvinceController(IProvinceApplication provinceApplication) => _provinceApplication = provinceApplication;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _provinceApplication.GetAll();
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
            
        }
    }
}