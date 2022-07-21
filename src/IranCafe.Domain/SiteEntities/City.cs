using Framework.Domain;

namespace IranCafe.Domain.SiteEntities
{
    public class City : EntityBase
	{
        public Guid ProvinceId { get;private set; }
        public string? Title { get; private set; }

        public Province Province { get; set; }

        public City(Guid provinceId, string? title)
        {
            ProvinceId = provinceId;
            Title = title;
        }

        public void Edit(Guid provinceId, string? title)
        {
            ProvinceId = provinceId;
            Title = title;
        }
    }
}