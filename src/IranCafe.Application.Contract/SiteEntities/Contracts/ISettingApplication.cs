using Framework.Application;

namespace IranCafe.Application.Contract.SiteEntities.Contracts
{
    public interface ISettingApplication
    {
        Task<SettingDto> GetSetting();
        Task<OperationResult> Modify(SettingDto command);
    }
}