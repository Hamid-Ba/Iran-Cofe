using Framework.Application;

namespace IranCafe.Application.Contract.SiteEntities.Contracts
{
    public interface IProvinceApplication
    {
        Task<OperationResult> Delete(Guid id);
        Task<IEnumerable<ProvinceDto>> GetAll();
        Task<EditProvinceDto> GetDetailForEditBy(Guid id);
        Task<OperationResult> Edit(EditProvinceDto command);
        Task<OperationResult> Create(CreateProvinceDto command);
    }
}