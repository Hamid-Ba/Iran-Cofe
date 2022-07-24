﻿using Framework.Domain.Cafe;
using Framework.Infrastructure;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class CafeRepository : Repository<Cafe>, ICafeRepository
    {
        private readonly CafeContext _context;

        public CafeRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<CafeAdminDto>> GetAllBy(CafeStatus status)
        {
            var users = await _context.Users.Select(u => new { Id = u.Id, FullName = u.FullName }).ToListAsync();

            var result = await _context.Cafes.Where(c => c.Status == status)
               .Select(c => new CafeAdminDto
               {
                   Id = c.Id,
                   UniqueCode = c.UniqueCode,
                   OwnerId = c.OwnerId,
                   FaTitle = c.FaTitle,
                   Status = c.Status,
                   Type = c.Type
               }).AsNoTracking().ToListAsync();

            result.ForEach(c => c.OwnerFullName = users.FirstOrDefault(u => u.Id == c.OwnerId)?.FullName);

            return result;
        }
    }
}