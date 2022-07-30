using Framework.Application;
using Framework.Infrastructure;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
    {
        private readonly CafeContext _context;

        public MenuItemRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<MenuItemDto>> GetAllBy(Guid cafeId, Guid? categoryId)
        {
            if(categoryId is null)
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
        
    }
}