using Framework.Application;
using Framework.Infrastructure;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore.Repositories.CafeAgg
{
    public class ReservationRepository : Repository<Reservation>, IReservationRepository
    {
        private readonly CafeContext _context;

        public ReservationRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<ReservationDto>> GetAll(Guid cafeId, Guid ownerId) => await _context.Reservations.Where(c => c.CafeId == cafeId && c.UserId == ownerId)
            .Select(r => new ReservationDto
            {
                Id = r.Id,
                CafeId = r.CafeId,
                UserId = r.UserId,
                FullName = r.FullName,
                Message = r.Message,
                Phone = r.Phone,
                PersianCreationDate = r.CreationDate.ToFarsi(),
                ReserveHourStr = r.ReserveHourStr,
                ReserveDateStr = r.ReserveDateStr,
                ReserveDate = r.ReserveDate,
            }).AsNoTracking().ToListAsync();

    }
}