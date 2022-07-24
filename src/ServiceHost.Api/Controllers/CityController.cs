using IranCafe.Application.Contract.SiteEntities.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class CityController : BaseApiController
    {
        private readonly ICityApplication _cityApplication;

        public CityController(ICityApplication cityApplication) => _cityApplication = cityApplication;

        [HttpGet("{provinceId}")]
        public async Task<IActionResult> GetAll(Guid provinceId)
        {
            try
            {
                var result = await _cityApplication.GetAllBy(provinceId);
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }
    }
}