using Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace IranCafe.Application.Contract.SiteEntities
{
    public class CityDto : EntityBaseDto
    {
        public Guid ProvinceId { get; set; }
        public string? Title { get; set; }
    }

    public class CreateCityDto
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public Guid ProvinceId { get; set; }

        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Title { get; set; }
    }

    public class EditCityDto : CreateCityDto
    {
        public Guid Id { get; set; }
    }
}