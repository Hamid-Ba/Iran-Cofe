using Framework.Application;

namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface ICategoryApplication
    {
        Task<OperationResult> Edit(EditCategoryDto command);
        Task<IEnumerable<CategoryDto>> GetAllBy(Guid cafeId);
        Task<OperationResult> Create(CreateCategoryDto command);
    }
}