using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using IranCafe.Domain.CafeAgg.Contracts;

namespace IranCafe.Application.CafeAgg
{
    public class MenuItemApplication : IMenuItemApplication
    {
        private readonly IMenuItemRepository _menuItemRepository;

        public MenuItemApplication(IMenuItemRepository menuItemRepository) => _menuItemRepository = menuItemRepository;

        public async Task<IEnumerable<MenuItemDto>> GetAllBy(Guid cafeId, Guid? categoryId) => await _menuItemRepository.GetAllBy(cafeId, categoryId);

        public async Task<DetailMenuItemDto> GetDetailBy(Guid id) => await _menuItemRepository.GetDetailBy(id);
        
    }
}