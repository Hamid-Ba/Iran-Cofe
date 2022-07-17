using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Framework.Api;
using IranCafe.Application.Contract.UserAgg;
using IranCafe.Application.Contract.UserAgg.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IUserApplication _userApplication;

        public AuthController(IUserApplication userApplication) => _userApplication = userApplication;

        [HttpPost("Login")]
        public async Task<IActionResult> LoginOrRegister([FromBody] LoginUserDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userApplication.LoginFirstStep(command);
                    return result.IsSucceeded ? Ok(result.Message) : Problem(result.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.InnerException?.Message); }
        }

        [HttpPost("Verify")]
        public async Task<IActionResult> GetTokenByVerification([FromBody]AccessTokenDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _userApplication.VerifyLoginRegister(command);
                    return result.Item1.IsSucceeded ? Ok(new
                    {
                        Message = result.Item1.Message,
                        Token = result.Item2
                    })
                    :
                    Problem(result.Item1.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.Message); }
            
        }
    }
}