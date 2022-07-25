using Framework.Infrastructure;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly CafeContext _context;

        public CategoryRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<CategoryDto>> GetAllBy(Guid cafeId) => await _context.Categories.Where(c => c.CafeId == cafeId).Select(c => new CategoryDto
        {
            Id = c.Id,
            CafeId = c.CafeId,
            Title = c.Title,
            Slug = c.Slug,
            ShortDesc = c.ShortDesc
        }).AsNoTracking().ToListAsync();
        
    }
}