using Framework.Domain;

namespace IranCafe.Domain.SiteEntities
{
    public class Province : EntityBase
    {
        public string? Title { get; private set; }

        public List<City> Cities { get; private set; }

        public Province(string? title) => Title = title;

        public void Edit(string? title) => Title = title;
    }
}