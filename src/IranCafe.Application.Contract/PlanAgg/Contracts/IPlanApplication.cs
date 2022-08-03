using Framework.Application;

namespace IranCafe.Application.Contract.PlanAgg.Contracts
{
    public interface IPlanApplication
    {
        Task<PlanVM> GetPlanBy(Guid id);
        Task<IEnumerable<PlanVM>> GetAll();
        Task<OperationResult> Delete(Guid id);
        Task<EditPlanVM> GetDetailForEditBy(Guid id);
        Task<OperationResult> Edit(EditPlanVM command);
        Task<OperationResult> Create(CreatePlanVM command);
    }
}