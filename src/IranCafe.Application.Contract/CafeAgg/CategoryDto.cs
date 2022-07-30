using Framework.Application;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IranCafe.Application.Contract.CafeAgg
{
    public class CategoryDto : EntityBaseDto
    {
        public string? Title { get; set; }
        public string? Slug { get; set; }
        public string? Logo { get; set; }
        public string? ShortDesc { get; set; }
    }

    public class CreateCategoryDto
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Title { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Slug { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public IFormFile? LogoFile { get; set; }

        public string? ShortDesc { get; set; }
    }

    public class EditCategoryDto : CreateCategoryDto
    {
        public Guid Id { get; set; }
        public string? Logo { get; set; }
    }
}