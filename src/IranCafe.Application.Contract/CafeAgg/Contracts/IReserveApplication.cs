using Framework.Application;

namespace IranCafe.Application.Contract.CafeAgg.Contracts
{
    public interface IReservationApplication
    {
        Task<OperationResult> Reserve(ReserveDto command);
        Task<IEnumerable<ReservationDto>> GetAll(Guid cafeId,Guid ownerId);
    }
}