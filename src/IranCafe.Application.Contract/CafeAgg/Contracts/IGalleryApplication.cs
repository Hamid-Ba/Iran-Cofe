using Framework.Application;

namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface IGalleryApplication
    {
        Task<GalleryDto> GetBy(Guid id, Guid cafeId);
        Task<OperationResult> Edit(EditGalleryDto command);
        Task<IEnumerable<GalleryDto>> GetAllBy(Guid cafeId);
        Task<OperationResult> Create(CreateGalleryDto command);
    }
}