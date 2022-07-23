using Framework.Application;
using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Application.Contract.SiteEntities.Contracts;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.SiteEntities.Contracts;

namespace IranCafe.Application.SiteEntities
{
    public class CityApplication : ICityApplication
    {
        private readonly ICityRepository _cityRepository;

        public CityApplication(ICityRepository cityRepository) => _cityRepository = cityRepository;

        public async Task<OperationResult> Create(CreateCityDto command)
        {
            OperationResult result = new();

            if (_cityRepository.Exists(c => c.Title == command.Title))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var city = new City(command.ProvinceId, command.Title!);

            await _cityRepository.AddEntityAsync(city);
            await _cityRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            OperationResult result = new();

            var city = await _cityRepository.GetEntityByIdAsync(id);
            if (city is null) return result.Failed(ApplicationMessage.NotExist);

            city.Delete();
            await _cityRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditCityDto command)
        {
            OperationResult result = new();

            var city = await _cityRepository.GetEntityByIdAsync(command.Id);
            
            if (city is null) return result.Failed(ApplicationMessage.NotExist);
            if (_cityRepository.Exists(c => c.Title == command.Title && c.ProvinceId == command.ProvinceId && c.Id != command.Id))
                return result.Failed(ApplicationMessage.NotExist);

            city.Edit(command.ProvinceId,command.Title);
            await _cityRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<IEnumerable<CityDto>> GeAllBy(Guid provinceId) => await _cityRepository.GetAllBy(provinceId);

        public async Task<CityDto> GetBy(Guid id) => await _cityRepository.GetBy(id);

        public async Task<EditCityDto> GetDetailForEditBy(Guid id) => await _cityRepository.GetDetailForEditBy(id);
    }
}