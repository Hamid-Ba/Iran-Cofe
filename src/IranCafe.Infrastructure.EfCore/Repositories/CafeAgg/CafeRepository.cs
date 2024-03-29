﻿using Framework.Application;
using Framework.Domain.Cafe;
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

        public async Task<IEnumerable<CafesDto>> GetAllBy(FilterCafesDto filter)
        {
            if (filter.IsCity)
            {
                return await _context.Cafes.Where(c => c.Status == CafeStatus.Confirmed && c.FaTitle!.Contains(filter.FaTitle!) && c.Type == filter.Type &&
                c.CityId == filter.ProvinceOrCityId).
                    Select(c => new CafesDto
                    {
                        Id = c.Id,
                        OwnerId = c.OwnerId,
                        UniqueCode = c.UniqueCode,
                        ImageUrl = c.ImageUrl,
                        InstagramId = c.InstagramId,
                        Type = c.Type,
                        View = c.View,
                        PersianRegisterDate = c.CreationDate.ToFarsi()
                    }).AsNoTracking().ToListAsync();
            }
            else
            {
                return await _context.Cafes.Where(c => c.Status == CafeStatus.Confirmed && c.FaTitle!.Contains(filter.FaTitle!) && c.Type == filter.Type &&
                c.ProvinceId == filter.ProvinceOrCityId).
                    Select(c => new CafesDto
                    {
                        Id = c.Id,
                        OwnerId = c.OwnerId,
                        UniqueCode = c.UniqueCode,
                        ImageUrl = c.ImageUrl,
                        InstagramId = c.InstagramId,
                        Type = c.Type,
                        View = c.View,
                        PersianRegisterDate = c.CreationDate.ToFarsi()
                    }).AsNoTracking().ToListAsync();
            }
        }

        public async Task<CafeDto> GetBy(string uniqueCode) => (await _context.Cafes.Where(c => c.Status == CafeStatus.Confirmed && c.UniqueCode == uniqueCode)
            .Select(c => new CafeDto
            {
                Id = c.Id,
                UniqueCode = c.UniqueCode,
                OwnerId = c.OwnerId,
                ProvinceId = c.ProvinceId,
                CityId = c.CityId,
                FaTitle = c.FaTitle,
                EnTitle = c.EnTitle,
                ImageUrl = c.ImageUrl,
                Slug = c.Slug,
                Phone = c.Phone,
                Desc = c.Desc,
                Email = c.Desc,
                GoogleMapUrl = c.GoogleMapUrl,
                InstagramId = c.InstagramId,
                PostalCode = c.PostalCode,
                QRCode = c.QRCode,
                ShortDesc = c.ShortDesc,
                Status = c.Status,
                Street = c.Street,
                TelegramId = c.TelegramId,
                Type = c.Type,
                View = c.View
            }).AsNoTracking().FirstOrDefaultAsync())!;
        
    }
}