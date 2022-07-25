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

        [HttpGet]
        public async Task<IActionResult> GetAllBy([FromQuery]FilterCafesDto filter)
        {
            try
            {
                var result = await _cafeApplication.GetAllBy(filter);
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }

        [HttpGet("{uniqueCode}")]
        public async Task<IActionResult> GetBy(string uniqueCode)
        {
            try
            {
                var result = await _cafeApplication.GetBy(uniqueCode);
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }

        [HttpPost("registerCafe")]
        public async Task<IActionResult> RegisterCafe([FromBody] RegisterCafeDto command)
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

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody] EditCafeDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _cafeApplication.Edit(command);
                    return result.IsSucceeded ? Ok(result.Message) : BadRequest(result.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }

        }
    }
}