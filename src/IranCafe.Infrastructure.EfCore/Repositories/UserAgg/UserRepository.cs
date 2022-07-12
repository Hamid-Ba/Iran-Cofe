using Framework.Infrastructure;
using IranCafe.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.UserAgg
{
    public class UserRepository : Repository<User>, IUserRepository
	{
        private readonly CafeContext _context;

        public UserRepository(CafeContext context) : base(context) => _context = context;

        public async Task<User> GetBy(string phone) => (await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone))!;
        
    }
}