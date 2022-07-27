using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryApplication _categoryApplication;

        public CategoryController(ICategoryApplication categoryApplication) => _categoryApplication = categoryApplication;


        [HttpGet()]
        public async Task<IActionResult> GetAllBy()
        {
            try
            {
                var result = await _categoryApplication.GetAllBy();
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }
    }
}