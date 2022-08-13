using IranCafe.Domain.UserAgg;

namespace IranCafe.Domain.EventAgg
{
    public class CustomerClubUsers
    {
        public Guid UserId { get; private set; }
        public Guid CustomerClubId { get; private set; }

        public User? User { get; private set; }
        public CustomerClub? CustomerClubs { get; private set; }
    }
}