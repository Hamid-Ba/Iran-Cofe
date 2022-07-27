using Framework.Domain;

namespace IranCafe.Domain.CafeAgg
{
    public class Category : EntityBase
    {
        public string? Title { get; private set; }
        public string? Slug { get; private set; }
        public string? Logo { get; private set; }
        public string? ShortDesc { get; private set; }

        public List<MenuItem>? Items { get; private set; }

        public Category(string? title, string? slug,string logo, string? shortDesc)
        {
            Title = title;
            Slug = slug;
            Logo = logo;
            ShortDesc = shortDesc;
        }

        public void Edit(string? title, string? slug,string logo, string? shortDesc)
        {
            Title = title;
            Slug = slug;

            if (!string.IsNullOrWhiteSpace(logo))
                Logo = logo;

            ShortDesc = shortDesc;
        }
    }
}