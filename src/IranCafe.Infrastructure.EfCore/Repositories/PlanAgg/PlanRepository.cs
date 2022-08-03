using Framework.Infrastructure;
using IranCafe.Application.Contract.PlanAgg;
using IranCafe.Domain.PlanAgg;
using IranCafe.Domain.PlanAgg.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.PlanAgg
{
    public class PlanRepository : Repository<Plan>, IPlanRepository
    {
        private readonly CafeContext _context;

        public PlanRepository(CafeContext context) : base(context) => _context = context;

        public async Task<PlanVM> GetPlanBy(Guid id) => (await _context.Plans.Select(p => new PlanVM()
        {
            Id = p.Id,
            Title = p.Title,
            PeriodPerDay = p.PeriodPerDay,
            Cost = p.Cost,
            Description = p.Description,
            Ps = p.Ps,
            ImageName = p.ImageName,
            OrderCount = p.OrderCount
        }).FirstOrDefaultAsync(p => p.Id == id))!;

        public async Task<EditPlanVM> GetDetailForEditBy(Guid id) => (await _context.Plans.Select(p => new EditPlanVM()
        {
            Id = p.Id,
            Title = p.Title,
            PeriodPerDay = p.PeriodPerDay,
            Cost = p.Cost,
            Description = p.Description,
            Ps = p.Ps,
            ImageName = p.ImageName
        }).FirstOrDefaultAsync(p => p.Id == id))!;

        public async Task<IEnumerable<PlanVM>> GetAll() => await _context.Plans.Select(p => new PlanVM()
        {
            Id = p.Id,
            Title = p.Title,
            PeriodPerDay = p.PeriodPerDay,
            Cost = p.Cost,
            Description = p.Description,
            Ps = p.Ps,
            ImageName = p.ImageName,
            OrderCount = p.OrderCount
        }).AsNoTracking().OrderByDescending(o => o.Id).ToListAsync();

    }
}