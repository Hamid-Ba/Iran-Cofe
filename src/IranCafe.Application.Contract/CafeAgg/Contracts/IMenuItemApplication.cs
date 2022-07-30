namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface IMenuItemApplication
    {
        Task<IEnumerable<MenuItemDto>> GetAllBy(Guid cafeId, Guid? categoryId);
    }
}
