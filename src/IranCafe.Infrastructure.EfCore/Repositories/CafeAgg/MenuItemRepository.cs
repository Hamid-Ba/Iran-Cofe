using Framework.Application;
using Framework.Infrastructure;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly CafeContext _context;

        public MenuItemRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<MenuItemDto>> GetAllBy(Guid cafeId, Guid? categoryId)
        {
            if (categoryId is null)
            {
                var items = await _context.MenuItems.Where(c => c.CafeId == cafeId && c.IsActive).Select(c => new MenuItemDto
                {
                    Id = c.Id,
                    CafeId = c.CafeId,
                    Title = c.Title,
                    CategoryId = c.CategoryId,
                    ImageUrl = c.ImageUrl,
                    ShortDesc = c.ShortDesc,
                    Price = c.Price,
                    PriceString = c.Price.ToMoney(),
                    PersianCreationDate = c.CreationDate.ToFarsi(),
                }).AsNoTracking().ToListAsync();

                return items;
            }

            var result = await _context.MenuItems.Where(c => c.CafeId == cafeId && c.CategoryId == categoryId && c.IsActive).Select(c => new MenuItemDto
            {
                Id = c.Id,
                CafeId = c.CafeId,
                Title = c.Title,
                CategoryId = c.CategoryId,
                ImageUrl = c.ImageUrl,
                ShortDesc = c.ShortDesc,
                Price = c.Price,
                PriceString = c.Price.ToMoney(),
                PersianCreationDate = c.CreationDate.ToFarsi(),
            }).AsNoTracking().ToListAsync();

            return result;
        }

        public async Task<DetailMenuItemDto> GetDetailBy(Guid id) => (await _context.MenuItems.Select(m => new DetailMenuItemDto
        {
            Id = m.Id,
            ImageUrl = m.ImageUrl,
            Desc = m.Desc
        }).AsNoTracking().FirstOrDefaultAsync(m => m.Id == id))!;
    }
}