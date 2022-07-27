using Framework.Domain;
using IranCafe.Application.Contract.CafeAgg;

namespace IranCafe.Domain.CafeAgg.Contracts
{
    public interface IGalleryRepository : IRepository<Gallery>
    {
        Task<GalleryDto> GetBy(Guid id, Guid cafeId);
        Task<IEnumerable<GalleryDto>> GetAllBy(Guid cafeId);
    }
}