using IranCafe.Application.Contract.CafeAgg.Contracts;
using Microsoft.AspNetCore.Http;
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

    }
}
