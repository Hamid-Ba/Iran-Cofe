using Framework.Domain;
using IranCafe.Application.Contract.PlanAgg;

namespace IranCafe.Domain.PlanAgg.Contracts
{
    public interface IPlanRepository : IRepository<Plan>
    {
        Task<PlanVM> GetPlanBy(Guid id);
        Task<IEnumerable<PlanVM>> GetAll();
        Task<EditPlanVM> GetDetailForEditBy(Guid id);
    }
}