using Framework.Domain;
using Framework.Domain.Cafe;
using IranCafe.Application.Contract.CafeAgg;

namespace IranCafe.Domain.CafeAgg.Contracts
{
    public interface ICafeRepository : IRepository<Cafe>
    {
        Task<IEnumerable<CafeAdminDto>> GetAllBy(CafeStatus status);
        Task<IEnumerable<CafesDto>> GetAllBy(Guid provinceOrCityId, bool isCity);
    }
}