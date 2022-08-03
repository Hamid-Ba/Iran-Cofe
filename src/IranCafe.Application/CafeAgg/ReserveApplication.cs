using Framework.Application;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranCafe.Application.CafeAgg
{
    public class ReservationApplication : IReservationApplication
    {
        private readonly IReservationRepository _reservationRepository;
        public ReservationApplication(IReservationRepository reservationRepository) => _reservationRepository = reservationRepository;

        public async Task<IEnumerable<ReservationDto>> GetAll(Guid cafeId, Guid ownerId) => await _reservationRepository.GetAll(cafeId, ownerId);

        public async Task<OperationResult> Reserve(ReserveDto command)
        {
            OperationResult result = new();

            var hour = int.Parse(command.ReserveHourStr!.Split(':')[0]);
            var minute = int.Parse(command.ReserveHourStr.Split(':')[1]);
            var compliteDate = command.ReserveDateStr!.GetCompliteDate(hour, minute);

            var reserve = new Reservation(command.CafeId, command.UserId, command.FullName!, command.Phone!
                , command.ReserveDateStr!, command.ReserveHourStr!,compliteDate, command.Message!);

            await _reservationRepository.AddEntityAsync(reserve);
            await _reservationRepository.SaveChangesAsync();

            return result.Succeeded();
        }
    }
}