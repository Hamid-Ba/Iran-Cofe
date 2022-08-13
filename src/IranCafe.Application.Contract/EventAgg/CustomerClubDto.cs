namespace IranCafe.Application.Contract.EventAgg
{
    public class CustomerClubDto : EntityBaseDto
    {
        public Guid CafeId { get; set; }
    }

    public class JoinCustomerClubDto
    {
        public Guid CafeId { get; set; }
        public Guid CustomerId { get; set; }
    }
}