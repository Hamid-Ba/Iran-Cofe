using Framework.Domain;
using IranCafe.Application.Contract.SiteEntities;

namespace IranCafe.Domain.SiteEntities.Contracts
{
    public interface ISettingRepository : IRepository<Setting>
    {
        Task<Setting> GetEntity();
        Task<SettingDto> GetSetting();
    }
}