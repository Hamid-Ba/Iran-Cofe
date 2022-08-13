using Framework.Domain;
using IranCafe.Domain.CafeAgg;

namespace IranCafe.Domain.EventAgg
{
    public class CustomerClub : EntityBase
    {
        public Guid CafeId { get; private set; }

        public Cafe? Cafe { get; private set; }
        public List<CustomerClubUsers>? Customers { get; private set; }

        public CustomerClub(Guid cafeId) => CafeId = cafeId;
    }
}