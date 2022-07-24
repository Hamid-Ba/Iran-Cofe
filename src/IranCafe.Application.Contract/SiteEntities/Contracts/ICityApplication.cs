using Framework.Application;

namespace IranCafe.Application.Contract.SiteEntities.Contracts
{
    public interface ICityApplication
    {
        Task<CityDto> GetBy(Guid id);
        Task<OperationResult> Delete(Guid id);
        Task<EditCityDto> GetDetailForEditBy(Guid id);
        Task<OperationResult> Edit(EditCityDto command);
        Task<OperationResult> Create(CreateCityDto command);
        Task<IEnumerable<CityDto>> GetAllBy(Guid provinceId);
    }
}