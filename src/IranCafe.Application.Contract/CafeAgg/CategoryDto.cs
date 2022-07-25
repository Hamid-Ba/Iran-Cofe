namespace IranCafe.Application.Contract.CafeAgg
{
    public class CategoryDto : EntityBaseDto
    {
        public Guid CafeId { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? ShortDesc { get; set; }
    }

    public class CreateCategoryDto
    {
        public Guid CafeId { get; set; }
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? ShortDesc { get; set; }
    }

    public class EditCategoryDto : CreateCategoryDto 
    {
        public Guid Id { get; set; }
    }

}