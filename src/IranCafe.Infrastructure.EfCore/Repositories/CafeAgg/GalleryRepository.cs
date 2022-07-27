using Framework.Infrastructure;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class GalleryRepository : Repository<Gallery>, IGalleryRepository
    {
        private readonly CafeContext _context;

        public GalleryRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<GalleryDto>> GetAllBy(Guid cafeId) => await _context.Galleries.Where(c => c.CafeId == cafeId)
            .Select(g => new GalleryDto
            {
                Id = g.Id,
                CafeId = g.CafeId,
                ImageUrl = g.ImageUrl,
                ImageName = g.ImageName,
                FolderPath = g.FolderPath,
            }).AsNoTracking().ToListAsync();

        public async Task<GalleryDto> GetBy(Guid id, Guid cafeId) => (await _context.Galleries.Where(c => c.CafeId == cafeId)
            .Select(g => new GalleryDto
            {
                Id = g.Id,
                CafeId = g.CafeId,
                ImageUrl = g.ImageUrl,
                ImageName = g.ImageName,
                FolderPath = g.FolderPath,
            }).AsNoTracking().FirstOrDefaultAsync(g => g.Id == id))!;
    }
}