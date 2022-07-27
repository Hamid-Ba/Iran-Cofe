namespace IranCafe.Application.Contract.CafeAgg
{
    public class CategoryDto : EntityBaseDto
    {
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? ShortDesc { get; set; }
    }

    public class CreateCategoryDto
    {
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? ShortDesc { get; set; }
    }

    public class EditCategoryDto : CreateCategoryDto 
    {
        public Guid Id { get; set; }
    }

}