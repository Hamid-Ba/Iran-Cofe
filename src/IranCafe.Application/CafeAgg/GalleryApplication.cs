using Framework.Application;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.AspNetCore.Http;

namespace IranCafe.Application.CafeAgg
{
    public class GalleryApplication : IGalleryApplication
    {
        private readonly HttpContext _current;
        private readonly ICafeRepository _cafeRepository;
        private readonly IGalleryRepository _galleryRepository;

        public GalleryApplication(ICafeRepository cafeRepository, IGalleryRepository galleryRepository, IHttpContextAccessor accessor)
        {
            _cafeRepository = cafeRepository;
            _galleryRepository = galleryRepository;
            _current = accessor.HttpContext!;
        }

        public async Task<OperationResult> Create(CreateGalleryDto command)
        {
            OperationResult result = new();

            var cafe = await _cafeRepository.GetEntityByIdAsync(command.CafeId);
            if (cafe is null) return result.Failed(ApplicationMessage.NotExist);

            var folderName = $"cafe\\{cafe.Slug}";
            var imageName = Uploader.ImageUploader(command.ImageFile!, folderName, null!);
            var imageUrl = $"{_current.Request.Scheme}://{_current.Request.Host}{_current.Request.PathBase}/Pictures//{imageName}";

            var gallery = new Gallery(command.CafeId, imageUrl, imageName, folderName);

            await _galleryRepository.AddEntityAsync(gallery);
            await _galleryRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditGalleryDto command)
        {
            OperationResult result = new();

            var gallery = await _galleryRepository.GetEntityByIdAsync(command.Id);
            if (gallery is null) return result.Failed(ApplicationMessage.NotExist);

            var cafe = await _cafeRepository.GetEntityByIdAsync(command.CafeId);
            if (cafe is null) return result.Failed(ApplicationMessage.NotExist);

            var folderName = $"cafe\\{cafe.Slug}";
            var imageName = Uploader.ImageUploader(command.ImageFile!, folderName, gallery.ImageName!);
            var imageUrl = $"{_current.Request.Scheme}://{_current.Request.Host}{_current.Request.PathBase}/Pictures//{imageName}";

            gallery.Edit(imageUrl, imageName);
            await _galleryRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<IEnumerable<GalleryDto>> GetAllBy(Guid cafeId) => await _galleryRepository.GetAllBy(cafeId);

        public async Task<GalleryDto> GetBy(Guid id, Guid cafeId) => await _galleryRepository.GetBy(id, cafeId);
    }
}