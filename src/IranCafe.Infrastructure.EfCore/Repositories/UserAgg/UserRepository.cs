using Framework.Application;
using Framework.Infrastructure;
using IranCafe.Application.Contract.UserAgg;
using IranCafe.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.UserAgg
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly CafeContext _context;

        public UserRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<UserDto>> GetAll(bool isDelete) => await _context.Users.Where(u => u.IsDelete == isDelete).Select(u => new UserDto
        {
            Id = u.Id,
            Phone = u.Phone,
            IsActive = u.IsActive,
            PersianCreationDate = u.CreationDate.ToFarsi(),
            PersianDeletionDate = u.DeletionDate.ToFarsi()
        }).AsNoTracking().ToListAsync();

        public async Task<User> GetBy(string phone) => (await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone))!;

        public async Task<UserDto> GetBy(Guid id) => (await _context.Users.IgnoreQueryFilters().Select(u => new UserDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Phone = u.Phone,
            Email = u.Email,
            PersianCreationDate = u.CreationDate.ToFarsi()
        }).AsNoTracking().FirstOrDefaultAsync(u => u.Id == id))!;

        public async Task<UserDto> GetByToken(string accessToken) => (await _context.Users.Where(u => u.AccessToken == accessToken).IgnoreQueryFilters().Select(u => new UserDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Phone = u.Phone,
            Email = u.Email,
            PersianCreationDate = u.CreationDate.ToFarsi()
        }).AsNoTracking().FirstOrDefaultAsync())!;

        public async Task<EditUserDto> GetDetailForEditBy(Guid id) => (await _context.Users.Select(u => new EditUserDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Email = u.Email
        }).AsNoTracking().FirstOrDefaultAsync(u => u.Id == id))!;

    }
}