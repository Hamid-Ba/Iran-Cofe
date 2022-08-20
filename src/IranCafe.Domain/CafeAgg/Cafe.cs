using Framework.Domain;
using Framework.Domain.Cafe;
using IranCafe.Domain.BlogAgg;
using IranCafe.Domain.EventAgg;
using IranCafe.Domain.SiteEntities;
using IranCafe.Domain.UserAgg;

namespace IranCafe.Domain.CafeAgg
{
    public class Cafe : EntityBase
    {
        public Guid ClubId { get; private set; }
        public Guid OwnerId { get; private set; }
        public Guid ProvinceId { get; private set; }
        public Guid CityId { get; private set; }
        public string? UniqueCode { get; private set; }
        public string? QRCode { get; private set; }
        public string? EnTitle { get; private set; }
        public string? FaTitle { get; private set; }
        public string ImageUrl { get; private set; }
        public string? Slug { get; private set; }
        public string? Phone { get; private set; }
        public string? Email { get; private set; }
        public string? InstagramId { get; private set; }
        public string? TelegramId { get; private set; }
        public string? Street { get; private set; }
        public string? PostalCode { get; private set; }
        public string? ShortDesc { get; private set; }
        public string? Desc { get; private set; }
        public string? GoogleMapUrl { get; private set; }
        public CafeStatus Status { get; private set; }
        public string? StatusDesc { get; private set; }
        public int View { get; private set; }
        public CafeType Type { get; private set; }

        public City? City { get; private set; }
        public CustomerClub? Club { get; private set; }
        public Province? Province { get; private set; }
        public List<User>? Users { get; private set; }
        public List<MenuItem>? Items { get; private set; }
        public List<Article>? Articles { get; private set; }
        public List<Gallery>? Galleries { get; private set; }
        public List<Reservation>? Reservations { get; private set; }

        public Cafe(Guid ownerId, Guid provinceId, Guid cityId, CafeType type, string uniqueCode, string enTitle, string faTitle, string slug, string phone, string street
            , string shortDesc, string desc)
        {
            OwnerId = ownerId;
            ProvinceId = provinceId;
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
            View = 0;
        }

        public void Edit(Guid provinceId, Guid cityId, string? enTitle, string? faTitle, string? slug,
            string? phone, string? email, string? instagramId, string? telegramId, string? street, string? postalCode, string? shortDesc,
            string? desc, CafeType type)
        {
            ProvinceId = provinceId;
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

            Type = type;

            LastUpdateDate = DateTime.Now;
        }

        public void ChangeImage(string newImageUrl) => ImageUrl = newImageUrl;

        public void ChangeStatus(CafeStatus status, string reason)
        {
            Status = status;

            if (!string.IsNullOrWhiteSpace(reason)) StatusDesc = reason;

            LastUpdateDate = DateTime.Now;
        }

        public void SetClub(Guid clubId) => ClubId = clubId;

        public void AddView() => View++;
    }
}