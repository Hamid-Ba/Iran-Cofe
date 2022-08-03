using Framework.Domain;
using IranCafe.Application.Contract.CafeAgg;

namespace IranCafe.Domain.CafeAgg.Contracts
{
    public interface IReservationRepository : IRepository<Reservation>
    {
        Task<IEnumerable<ReservationDto>> GetAll(Guid cafeId, Guid ownerId);
    }
}