using Framework.Api;
using IranCafe.Application.Contract.UserAgg;
using IranCafe.Application.Contract.UserAgg.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    [Authorize]
    public class UserController : BaseApiController
    {
        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication) => _userApplication = userApplication;

        [HttpPut]
        public async Task<IActionResult> Edit(EditUserDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userApplication.Edit(command);
                    return result.IsSucceeded ? Ok(result.Message) : BadRequest(result.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }
    }
}