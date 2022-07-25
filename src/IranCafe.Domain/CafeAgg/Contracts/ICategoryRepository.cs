using Framework.Domain;
using IranCafe.Application.Contract.CafeAgg;

namespace IranCafe.Domain.CafeAgg.Contracts
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<IEnumerable<CategoryDto>> GetAllBy(Guid cafeId);
    }
}