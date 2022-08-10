using Framework.Application;
using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Application.Contract.SiteEntities.Contracts;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.SiteEntities.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranCafe.Application.SiteEntities
{
    public class SettingApplication : ISettingApplication
    {
        private readonly ISettingRepository _settingRepository;

        public SettingApplication(ISettingRepository settingRepository) => _settingRepository = settingRepository;

        public async Task<SettingDto> GetSetting() => await _settingRepository.GetSetting();

        public async Task<OperationResult> Modify(SettingDto command)
        {
            OperationResult result = new();

            var setting = await _settingRepository.GetEntity();

            if (setting is null)
            {
                var baseSetting = new Setting(command.Mobiles, command.Emails, command.Text, command.SummaryText);
                await _settingRepository.AddEntityAsync(baseSetting);
            }
            else setting.Edit(command.Mobiles, command.Emails, command.Text, command.SummaryText);

            await _settingRepository.SaveChangesAsync();
            return result.Succeeded();
        }
    }
}
