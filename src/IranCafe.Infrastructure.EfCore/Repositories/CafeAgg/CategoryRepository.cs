using Framework.Infrastructure;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private readonly CafeContext _context;
        private readonly HttpContext _current;

        public CategoryRepository(CafeContext context, IHttpContextAccessor accessor) : base(context)
        {
            _context = context;
            _current = accessor.HttpContext!;
        }

        public async Task<IEnumerable<CategoryDto>> GetAllBy() => await _context.Categories.Select(c => new CategoryDto
        {
            Id = c.Id,
            Title = c.Title,
            Slug = c.Slug,
            Logo = $"{_current.Request.Scheme}://{_current.Request.Host}{_current.Request.PathBase}/Pictures//{c.Logo}",
            ShortDesc = c.ShortDesc
        }).AsNoTracking().ToListAsync();
    }
}