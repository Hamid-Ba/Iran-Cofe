using Framework.Domain;
using IranCafe.Application.Contract.SiteEntities;

namespace IranCafe.Domain.SiteEntities.Contracts
{
    public interface ICityRepository : IRepository<City>
    {
        Task<IEnumerable<CityDto>> GetAllBy(Guid provinceId);
        Task<CityDto> GetBy(Guid id);
        Task<EditCityDto> GetDetailForEditBy(Guid id);
    }
}