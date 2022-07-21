using Framework.Infrastructure;
using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.SiteEntities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.SiteEntities
{
    public class ProvinceRepository : Repository<Province>, IProvinceRepository
    {
        private readonly CafeContext _context;

        public ProvinceRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<ProvinceDto>> GetAll() => await _context.Provinces.Select(p => new ProvinceDto
        {
            Id = p.Id,
            Title = p.Title,
            CityCount = p.Cities!.Count()
        }).AsNoTracking().ToListAsync();

        public async Task<EditProvinceDto> GetDetailForEditBy(Guid id) => (await _context.Provinces.Select(p => new EditProvinceDto
        {
            Id = p.Id,
            Title = p.Title
        }).AsNoTracking().FirstOrDefaultAsync(p => p.Id == id))!;
        
    }
}