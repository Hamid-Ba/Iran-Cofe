using Framework.Application;
using IranCafe.Application.Contract.SiteEntities;
using IranCafe.Application.Contract.SiteEntities.Contracts;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.SiteEntities.Contracts;

namespace IranCafe.Application.SiteEntities
{
    public class ProvinceApplication : IProvinceApplication
    {
        private readonly IProvinceRepository _provinceRepository;

        public ProvinceApplication(IProvinceRepository provinceRepository) => _provinceRepository = provinceRepository;

        public async Task<OperationResult> Create(CreateProvinceDto command)
        {
            OperationResult result = new();

            if (_provinceRepository.Exists(p => p.Title == command.Title!.Trim())) return result.Failed(ApplicationMessage.DuplicatedModel);

            var province = new Province(command.Title!);
            
            await _provinceRepository.AddEntityAsync(province);
            await _provinceRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            OperationResult result = new();

            var province = await _provinceRepository.GetEntityByIdAsync(id);
            if (province is null) return result.Failed(ApplicationMessage.NotExist);

            province.Delete();
            await _provinceRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditProvinceDto command)
        {
            OperationResult result = new();

            var province = await _provinceRepository.GetEntityByIdAsync(command.Id);
            
            if (province is null) return result.Failed(ApplicationMessage.NotExist);
            if (_provinceRepository.Exists(p => p.Title == command.Title!.Trim() && p.Id != command.Id))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            province.Edit(command.Title!);
            await _provinceRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<IEnumerable<ProvinceDto>> GetAll() => await _provinceRepository.GetAll();

        public async Task<EditProvinceDto> GetDetailForEditBy(Guid id) => await _provinceRepository.GetDetailForEditBy(id);
    }
}