using Framework.Infrastructure;
using IranCafe.Domain.EventAgg;
using IranCafe.Domain.EventAgg.Contracts;

namespace IranCafe.Infrastructure.EfCore.Repositories.EventAgg
{
    public class CustomerClubUsersRepository : Repository<CustomerClubUsers>, ICustomerClubUsersRepository
    {
        private readonly CafeContext _context;

        public CustomerClubUsersRepository(CafeContext context) : base(context) => _context = context;
    }
}