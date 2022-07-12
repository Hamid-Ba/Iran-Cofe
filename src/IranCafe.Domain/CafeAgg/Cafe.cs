using Framework.Domain;
using Framework.Domain.Cafe;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.UserAgg;

namespace IranCafe.Domain.CafeAgg
{
    public class Cafe : EntityBase
	{
        public Guid OwnerId { get;private set; }
        public Guid CityId { get;private set; }
        public string? UniqueCode { get;private set; }
        public string? QRCode { get;private set; }
        public string? EnTitle { get;private set; }
        public string? FaTitle { get;private set; }
        public string? Slug { get;private set; }
        public string? Phone { get;private set; }
        public string? Email { get;private set; }
        public string? InstagramId { get;private set; }
        public string? TelegramId { get;private set; }
        public string? Street { get;private set; }
        public string? PostalCode { get;private set; }
        public string? ShortDesc { get;private set; }
        public string? Desc { get;private set; }
        public string? GoogleMapUrl { get;private set; }
        public CafeStatus Status { get;private set; }
        public string? StatusDesc { get;private set; }
        public CafeType Type { get;private set; }

        public City? City { get;private set; }
        public List<User>? Users { get; private set; }
        public List<MenuItem>? Items { get;private set; }

        public Cafe(Guid ownerId,Guid cityId,CafeType type,string uniqueCode,string enTitle,string faTitle,string slug,string phone,string street
            ,string shortDesc,string desc)
        {
            OwnerId = ownerId;
            CityId = cityId;
            Type = type;
            UniqueCode = uniqueCode;
            EnTitle = enTitle;
            FaTitle = faTitle;
            Slug = slug;
            Phone = phone;
            Street = street;
            ShortDesc = shortDesc;
            Desc = desc;
        }

        public void Edit(Guid ownerId, Guid cityId, string? enTitle, string? faTitle, string? slug,
            string? phone, string? email, string? instagramId, string? telegramId, string? street, string? postalCode,string? shortDesc,
            string? desc, string? googleMapUrl, CafeType type)
        {
            OwnerId = ownerId;
            CityId = cityId;
            
            EnTitle = enTitle;
            FaTitle = faTitle;
            Slug = slug;
            Phone = phone;
            Email = email;
            InstagramId = instagramId;
            TelegramId = telegramId;
            Street = street;
            PostalCode = postalCode;
            ShortDesc = shortDesc;
            Desc = desc;

            GoogleMapUrl = googleMapUrl;
            
            Type = type;
        }

        public void ChangeStatus(CafeStatus status, string reason)
        {
            Status = status;

            if (!string.IsNullOrWhiteSpace(reason)) StatusDesc = reason;

            LastUpdateDate = DateTime.Now;
        }
    }
}