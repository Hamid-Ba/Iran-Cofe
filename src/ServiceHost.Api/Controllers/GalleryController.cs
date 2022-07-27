using Framework.Api;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.Api.Controllers
{
    public class GalleryController : BaseApiController
    {
        private readonly IGalleryApplication _galleryApplication;

        public GalleryController(IGalleryApplication galleryApplication) => _galleryApplication = galleryApplication;

        [HttpGet("{cafeId}")]
        public async Task<IActionResult> GetAllBy(Guid cafeId)
        {
            try
            {
                var result = await _galleryApplication.GetAllBy(cafeId);
                return Ok(result);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }

        [HttpGet("{cafeId}/{id}")]
        public async Task<IActionResult> GetBy(Guid cafeId , Guid id)
        {
            try
            {
                var result = await _galleryApplication.GetBy(id, cafeId);
                return result == default ? Problem(ApiResultMessages.NotFound) : Ok(result);
                
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateGalleryDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _galleryApplication.Create(command);
                    return result.IsSucceeded ? Ok(result.Message) : Problem(result.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromForm]EditGalleryDto command)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _galleryApplication.Edit(command);
                    return result.IsSucceeded ? Ok(result.Message) : Problem(result.Message);
                }

                return BadRequest(ApiResultMessages.ModelStateNotValid);
            }
            catch (Exception e) { return BadRequest(e.InnerException!.Message); }
        }
    }
}