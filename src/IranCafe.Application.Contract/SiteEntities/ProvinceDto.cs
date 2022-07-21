using Framework.Application;
using System.ComponentModel.DataAnnotations;

namespace IranCafe.Application.Contract.SiteEntities
{
    public class ProvinceDto : EntityBaseDto
    {
        public string? Title { get; set; }
        public int CityCount { get; set; }
    }

    public class CreateProvinceDto 
    {
        [Required(ErrorMessage = ValidationMessage.IsRequired)]
        public string? Title { get; set; }
    }

    public class EditProvinceDto : CreateProvinceDto
    {
        public Guid Id { get; set; }
    }
}