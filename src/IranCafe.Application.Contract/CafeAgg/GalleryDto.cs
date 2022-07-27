using Microsoft.AspNetCore.Http;

namespace IranCafe.Application.Contract.CafeAgg
{
    public class GalleryDto : EntityBaseDto
    {
        public Guid CafeId { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageName { get; set; }
        public string? FolderPath { get; set; }
    }

    public class CreateGalleryDto
    {
        public Guid CafeId { get; set; }
        public IFormFile? ImageFile { get; set; }
    }

    public class EditGalleryDto : CreateGalleryDto
    {
        public Guid Id { get; set; }
    }
}