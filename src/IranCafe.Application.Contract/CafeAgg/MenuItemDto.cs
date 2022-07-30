namespace IranCafe.Application.Contract.CafeAgg
{
    public class MenuItemDto : EntityBaseDto
    {
        public Guid CafeId { get; set; }
        public Guid CategoryId { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public string? ShortDesc { get; set; }
        public string? Desc { get; set; }
        public double Price { get; set; }
        public string? PriceString { get; set; }
        public bool IsActive { get; set; }
    }
}
