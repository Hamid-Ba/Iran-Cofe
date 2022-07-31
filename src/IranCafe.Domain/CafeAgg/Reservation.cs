using Framework.Domain;
using IranCafe.Domain.UserAgg;

namespace IranCafe.Domain.CafeAgg
{
    public class Reservation : EntityBase
    {
        public Guid CafeId { get; private set; }
        public Guid UserId { get; private set; }
        public string? FullName { get; private set; }
        public string? Phone { get; private set; }
        public string? ReserveDateStr { get; private set; }
        public string? ReserveHourStr { get; private set; }
        public DateTime ReserveDate { get; private set; }
        public string? Message { get; private set; }

        public Cafe? Cafe { get; private set; }
        public User? User { get; private set; }

        public Reservation(Guid cafeId, Guid userId, string? fullName, string? phone, string? reserveDateStr, string? reserveHourStr, DateTime reserveDate, string? message)
        {
            CafeId = cafeId;
            UserId = userId;
            FullName = fullName;
            Phone = phone;
            ReserveDateStr = reserveDateStr;
            ReserveHourStr = reserveHourStr;
            ReserveDate = reserveDate;
            Message = message;
        }
    }
}