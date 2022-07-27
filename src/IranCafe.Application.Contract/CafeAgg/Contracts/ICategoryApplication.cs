using Framework.Application;

namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface ICategoryApplication
    {
        Task<IEnumerable<CategoryDto>> GetAllBy();
        Task<EditCategoryDto> GetDetailForEditBy(Guid id);
        Task<OperationResult> Edit(EditCategoryDto command);
        Task<OperationResult> Create(CreateCategoryDto command);
    }
}