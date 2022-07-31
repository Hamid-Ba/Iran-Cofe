namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface IMenuItemApplication
    {
        Task<DetailMenuItemDto> GetDetailBy(Guid id);
        Task<IEnumerable<MenuItemDto>> GetAllBy(Guid cafeId, Guid? categoryId);
    }
}
