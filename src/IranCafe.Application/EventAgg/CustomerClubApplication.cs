using IranCafe.Domain.EventAgg.Contracts;

namespace IranCafe.Application.EventAgg
{
    public class CustomerClubApplication 
    {
        private readonly ICustomerClubRepository _customerClubRepository;

        public CustomerClubApplication(ICustomerClubRepository customerClubRepository) => _customerClubRepository = customerClubRepository;
    }
}
