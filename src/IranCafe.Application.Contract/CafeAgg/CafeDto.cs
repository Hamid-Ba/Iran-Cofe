using Framework.Domain.Cafe;

namespace IranCafe.Application.Contract.CafeAgg
{
    public class CafeDto : EntityBaseDto
    {
        public Guid OwnerId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid CityId { get; set; }
        public string? UniqueCode { get; set; }
        public string? QRCode { get; set; }
        public string? EnTitle { get; set; }
        public string? FaTitle { get; set; }
        public string? ImageUrl { get; set; }
        public string? Slug { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramId { get; set; }
        public string? TelegramId { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? ShortDesc { get; set; }
        public string? Desc { get; set; }
        public string? GoogleMapUrl { get; set; }
        public CafeStatus Status { get; set; }
        public string? StatusDesc { get; set; }
        public int View { get; set; }
        public CafeType Type { get; set; }
    }

    public class CafeAdminDto
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string? OwnerFullName { get; set; }
        public string? UniqueCode { get; set; }
        public string? FaTitle { get; set; }
        public CafeType Type { get; set; }
        public CafeStatus Status { get; set; }
        public string? PersianCreationDate { get; set; }
    }

    public class RegisterCafeDto
    {
        public Guid OwnerId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid CityId { get; set; }
        public string? EnTitle { get; set; }
        public string? FaTitle { get; set; }
        public string? Slug { get; set; }
        public string? Phone { get; set; }
        public string? Street { get; set; }
        public string? ShortDesc { get; set; }
        public string? Desc { get; set; }
        public CafeType Type { get; set; }
    }

    public class EditCafeDto
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public Guid ProvinceId { get; set; }
        public Guid CityId { get; set; }
        public string? UniqueCode { get; set; }
        public string? EnTitle { get; set; }
        public string? FaTitle { get; set; }
        public string? Slug { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramId { get; set; }
        public string? TelegramId { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public string? ShortDesc { get; set; }
        public string? Desc { get; set; }
        public CafeType Type { get; set; }
    }

    public class CafesDto
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public string? UniqueCode { get; set; }
        public int View { get; set; }
        public CafeType Type { get; set; }
        public string? PersianRegisterDate { get; set; }
        public string? InstagramId { get; set; }
        public string? ImageUrl { get; set; }

    }

    public class FilterCafesDto
    {
        public string? FaTitle { get; set; }
        public bool IsCity { get; set; }
        public Guid ProvinceOrCityId { get; set; }
        public CafeType Type { get; set; }
    }

    public class ChangeCafeStatusDto
    {
        public Guid Id { get; set; }
        public CafeStatus Status { get; set; }
        public string? Reason { get; set; }
    }
}