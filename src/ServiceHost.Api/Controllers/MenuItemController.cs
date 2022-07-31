using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class MenuItemController : BaseApiController
    {
        private readonly IMenuItemApplication _menuItemApplication;

        public MenuItemController(IMenuItemApplication menuItemApplication) => _menuItemApplication = menuItemApplication;

        [HttpGet("{cafeId}/{categoryId?}")]
        public async Task<IActionResult> GetlAllBy(Guid cafeId, Guid? categoryId)
        {
            try
            {
                var result = await _menuItemApplication.GetAllBy(cafeId, categoryId);
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetailBy(Guid id)
        {
            try
            {
                var result = await _menuItemApplication.GetDetailBy(id);
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }
    }
}