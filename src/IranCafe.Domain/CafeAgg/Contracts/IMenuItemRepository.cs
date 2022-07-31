using Framework.Domain;
using IranCafe.Application.Contract.CafeAgg;

namespace IranCafe.Domain.CafeAgg.Contracts
{
    public interface IMenuItemRepository : IRepository<MenuItem>
    {
        Task<IEnumerable<MenuItemDto>> GetAllBy(Guid cafeId, Guid? categoryId);
        Task<DetailMenuItemDto> GetDetailBy(Guid id);
    }
}