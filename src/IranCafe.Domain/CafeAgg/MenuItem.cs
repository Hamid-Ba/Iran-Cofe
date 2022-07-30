using Framework.Domain;

namespace IranCafe.Domain.CafeAgg
{
    public class MenuItem : EntityBase
    {
        public Guid CafeId { get; private set; }
        public Guid CategoryId { get; private set; }
        public string? ImageUrl { get; private set; }
        public string? Title { get; private set; }
        public string? ShortDesc { get; private set; }
        public string? Desc { get;private set; }
        public double Price { get; private set; }
        public bool IsActive { get; private set; }

        public Cafe? Cafe { get; private set; }
        public Category? Category { get; private set; }

        public MenuItem(Guid cafeId, Guid categoryId, string? imageUrl, string? title, string? shortDesc,string? desc, double price, bool isActive)
        {
            CafeId = cafeId;
            CategoryId = categoryId;
            ImageUrl = imageUrl;
            Title = title;
            ShortDesc = shortDesc;
            Desc = desc;
            Price = price;
            IsActive = isActive;
        }

        public void Edit(Guid categoryId, string? imageUrl, string? title, string? shortDesc, string? desc, double price)
        {
            CategoryId = categoryId;
            ImageUrl = imageUrl;
            Title = title;
            ShortDesc = shortDesc;
            Desc = desc;
            Price = price;

            LastUpdateDate = DateTime.Now;
        }

        public void ChangeActivation(bool isActive)
        {
            IsActive = isActive;

            LastUpdateDate = DateTime.Now;
        }
    }
}