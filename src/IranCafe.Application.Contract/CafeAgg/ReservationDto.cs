using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IranCafe.Application.Contract.CafeAgg
{
    public class ReservationDto : EntityBaseDto
    {
        public Guid CafeId { get; set; }
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? ReserveDateStr { get; set; }
        public string? ReserveHourStr { get; set; }
        public DateTime ReserveDate { get; set; }
        public string? Message { get; set; }
    }

    public class ReserveDto
    {
        public Guid CafeId { get; set; }
        public Guid UserId { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? ReserveDateStr { get; set; }
        public string? ReserveHourStr { get; set; }
        public string? Message { get; set; }
    }
}