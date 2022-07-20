﻿using Framework.Infrastructure;
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
            CreationDate = u.CreationDate,
            DeletionDate = u.DeletionDate
        }).AsNoTracking().ToListAsync();

        public async Task<User> GetBy(string phone) => (await _context.Users.FirstOrDefaultAsync(u => u.Phone == phone))!;

        public async Task<UserDto> GetBy(Guid id) => (await _context.Users.IgnoreQueryFilters().Select(u => new UserDto
        {
            Id = u.Id,
            FullName = u.FullName,
            Phone = u.Phone,
            Email = u.Email,
            CreationDate = u.CreationDate
        }).AsNoTracking().FirstOrDefaultAsync(u => u.Id == id))!;
    }
}