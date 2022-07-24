using Framework.Infrastructure;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class CafeRepository : Repository<Cafe>, ICafeRepository
    {
        private readonly CafeContext _context;

        public CafeRepository(CafeContext context) : base(context) => _context = context;

    }
}