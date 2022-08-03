using Framework.Application;
using IranCafe.Application.Contract.PlanAgg;
using IranCafe.Application.Contract.PlanAgg.Contracts;
using IranCafe.Domain.PlanAgg;
using IranCafe.Domain.PlanAgg.Contracts;

namespace IranCafe.Application.PlanAgg
{
    public class PlanApplication : IPlanApplication
    {
        private readonly IPlanRepository _planRepository;

        public PlanApplication(IPlanRepository planRepository) => _planRepository = planRepository;

        public async Task<PlanVM> GetPlanBy(Guid id) => await _planRepository.GetPlanBy(id);

        public async Task<OperationResult> Create(CreatePlanVM command)
        {
            OperationResult result = new();

            if (_planRepository.Exists(p => p.PeriodPerDay == command.PeriodPerDay))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var imageName = Uploader.ImageUploader(command.ImageFile!, "Plan", null!);

            var plan = new Plan(command.Title!, command.PeriodPerDay, imageName, command.Cost, command.Description!,
                command.Ps!);

            await _planRepository.AddEntityAsync(plan);
            await _planRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditPlanVM command)
        {
            OperationResult result = new();

            var plan = await _planRepository.GetEntityByIdAsync(command.Id);

            if (plan is null) return result.Failed(ApplicationMessage.NotExist);
            if (_planRepository.Exists(p => p.PeriodPerDay == command.PeriodPerDay && p.Id != command.Id))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var imageName = Uploader.ImageUploader(command.ImageFile!, "Plan", command.ImageName!);

            plan.Edit(command.Title!, command.PeriodPerDay, imageName, command.Cost, command.Description!,
                command.Ps!);

            await _planRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            OperationResult result = new();

            var plan = await _planRepository.GetEntityByIdAsync(id);
            if (plan is null) return result.Failed(ApplicationMessage.DuplicatedModel);

            plan.Delete();

            await _planRepository.SaveChangesAsync();
            return result.Succeeded();
        }

        public async Task<EditPlanVM> GetDetailForEditBy(Guid id) => await _planRepository.GetDetailForEditBy(id);

        public async Task<IEnumerable<PlanVM>> GetAll() => await _planRepository.GetAll();
    }
}