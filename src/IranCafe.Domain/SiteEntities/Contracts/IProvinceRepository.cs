using Framework.Domain;
using IranCafe.Application.Contract.SiteEntities;

namespace IranCafe.Domain.SiteEntities.Contracts
{
    public interface IProvinceRepository : IRepository<Province>
    {
        Task<IEnumerable<ProvinceDto>> GetAll();
        Task<EditProvinceDto> GetDetailForEditBy(Guid id);
    }
}