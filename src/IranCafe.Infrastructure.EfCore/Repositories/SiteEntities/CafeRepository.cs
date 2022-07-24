using Framework.Infrastructure;
using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.SiteEntities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.SiteEntities
{
    public class CityRepository : Repository<City>, ICityRepository
    {
        private readonly CafeContext _context;
        public CityRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<CityDto>> GetAllBy(Guid provinceId) => await _context.City.Where(p => p.ProvinceId == provinceId)
            .Select(c => new CityDto
            {
                Id = c.Id,
                ProvinceId = c.ProvinceId,
                Title = c.Title,
                CreationDate = c.CreationDate
            }).AsNoTracking().ToListAsync();


        public async Task<CityDto> GetBy(Guid id) => (await _context.City.Select(c => new CityDto
        {
            Id = c.Id,
            ProvinceId = c.ProvinceId,
            Title = c.Title,
            CreationDate = c.CreationDate
        }).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id))!;


        public async Task<EditCityDto> GetDetailForEditBy(Guid id) => (await _context.City.Select(c => new EditCityDto
        {
            Id = c.Id,
            ProvinceId = c.ProvinceId,
            Title = c.Title
        }).AsNoTracking().FirstOrDefaultAsync(c => c.Id == id))!;

    }
}