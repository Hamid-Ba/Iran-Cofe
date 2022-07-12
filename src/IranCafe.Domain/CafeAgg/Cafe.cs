using Framework.Domain;
using Framework.Domain.Cafe;

namespace IranCafe.Domain.CafeAgg
{
    public class Cafe : EntityBase
	{
        public Guid OwnerId { get;private set; }
        public string UniqueCode { get;private set; }
        public string EnTitle { get;private set; }
        public string FaTitle { get;private set; }
        public string Slug { get;private set; }
        public string Phone { get;private set; }
        public string Email { get;private set; }
        public string InstagramId { get;private set; }
        public string TelegramId { get;private set; }
        public string Street { get;private set; }
        public string PostalCode { get;private set; }
        public string ShortDesc { get;private set; }
        public string Desc { get;private set; }
        public bool IsActive { get;private set; }
        public string GoogleMapUrl { get;private set; }
        public CafeStatus Status { get;private set; }
        public string StatusDesc { get;private set; }
        public CafeType Type { get;private set; }

        //List Of Users
    }
}