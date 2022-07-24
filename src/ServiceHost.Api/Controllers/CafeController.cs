using Framework.Api;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    [Authorize]
    public class CafeController : BaseApiController
    {
        private readonly ICafeApplication _cafeApplication;

        public CafeController(ICafeApplication cafeApplication) => _cafeApplication = cafeApplication;

        [HttpPost("registerCafe")]
        public async Task<IActionResult> RegisterCafe([FromBody]RegisterCafeDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _cafeApplication.Register(command);
                    return result.IsSucceeded ? Ok(result.Message) : BadRequest(result.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }
    }
}