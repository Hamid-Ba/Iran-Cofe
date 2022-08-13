using Framework.Infrastructure;
using IranCafe.Domain.EventAgg;
using IranCafe.Domain.EventAgg.Contracts;

namespace IranCafe.Infrastructure.EfCore.Repositories.EventAgg
{
    public class CustomerClubRepository : Repository<CustomerClub>, ICustomerClubRepository
    {
        private readonly CafeContext _context;

        public CustomerClubRepository(CafeContext context) : base(context) => _context = context;
    }
}