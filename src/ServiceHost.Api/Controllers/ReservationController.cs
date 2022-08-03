using Framework.Api;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class ReservationController : BaseApiController
    {
        private readonly IReservationApplication _reservationApplication;

        public ReservationController(IReservationApplication reservationApplication) => _reservationApplication = reservationApplication;

        [HttpGet("{ownerId}/{cafeId}")]
        public async Task<IActionResult> GetAll(Guid ownerId,Guid cafeId)
        {
            try
            {
                var result = await _reservationApplication.GetAll(cafeId, ownerId);
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Reserve([FromBody]ReserveDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _reservationApplication.Reserve(command);
                    return result.IsSucceeded ? Ok(result.Message) : Problem(result.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }
    }
}