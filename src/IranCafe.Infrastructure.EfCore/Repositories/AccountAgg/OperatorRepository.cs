using Framework.Infrastructure;
using IranCafe.Application.Contract.AccountAgg;
using IranCafe.Domain.AccountAgg;
using IranCafe.Domain.AccountAgg.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.AccountAgg
{
    public class OperatorRepository : Repository<Operator>, IOperatorRepository
    {
        private readonly CafeContext _context;

        public OperatorRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<OperatorDto>> GetAll() => await _context.Operators.Select(o => new OperatorDto
        {
            Id = o.Id,
            FullName = o.FullName,
            Mobile = o.Mobile,
        }).AsNoTracking().ToListAsync();

        public async Task<Operator> GetBy(string mobile) => (await _context.Operators.FirstOrDefaultAsync(o => o.Mobile == mobile))!;

        public async Task<EditOperatorDto> GetDetailForEditBy(Guid id) => (await _context.Operators.Select(o => new EditOperatorDto
        {
            Id = o.Id,
            FullName = o.FullName,
            Mobile = o.Mobile,
        }).AsNoTracking().FirstOrDefaultAsync(o => o.Id == id))!;
    }
}