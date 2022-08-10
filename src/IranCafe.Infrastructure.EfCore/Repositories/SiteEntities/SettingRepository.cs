using Framework.Infrastructure;
using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.SiteEntities.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.SiteEntities
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly CafeContext _context;

        public SettingRepository(CafeContext context) : base(context) => _context = context;

        public async Task<Setting> GetEntity() => (await _context.Settings.FirstOrDefaultAsync())!;

        public async Task<SettingDto> GetSetting() => (await _context.Settings.Select(s =>
            new SettingDto()
            {
                Text = s.Text,
                Emails = s.Emails,
                Mobiles = s.Mobiles,
                SummaryText = s.SummaryText
            }).FirstOrDefaultAsync())!;

    }
}