using Framework.Domain;
using Framework.Domain.Cafe;
using IranCafe.Application.Contract.CafeAgg;

namespace IranCafe.Domain.CafeAgg.Contracts
{
    public interface ICafeRepository : IRepository<Cafe>
    {
        Task<CafeDto> GetBy(string uniqueCode);
        Task<IEnumerable<CafeAdminDto>> GetAllBy(CafeStatus status);
        Task<IEnumerable<CafesDto>> GetAllBy(FilterCafesDto filter);
    }
}