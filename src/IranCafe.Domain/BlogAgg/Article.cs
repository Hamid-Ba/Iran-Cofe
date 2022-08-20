using Framework.Domain;
using Framework.Domain.Cafe;
using IranCafe.Domain.CafeAgg;

namespace IranCafe.Domain.BlogAgg
{
    public class Article : EntityBase
    {
        public Guid CafeId { get; private set; }
        public string Title { get; private set; }
        public string PictureName { get; private set; }
        public DateTime PublishDate { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public long View { get; private set; }
        public ArticleStatus Status { get; private set; }
        public string StatusDescriber { get; private set; }

        public Cafe Cafe { get; private set; }

        public Article(Guid cafeId,string title, string pictureName, DateTime publishDate, string shortDescription,
            string description, string slug, string keywords, string metaDescription)
        {
            CafeId = cafeId;
            Title = title;
            PictureName = pictureName;
            PublishDate = publishDate;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            View = 0;
            Status = ArticleStatus.Pending;
        }

        public void Edit(string title, string pictureName, DateTime publishDate, string shortDescription,
            string description, string slug, string keywords, string metaDescription)
        {
            Title = title;
            PictureName = pictureName;
            PublishDate = publishDate;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            View = 0;
            Status = ArticleStatus.Pending;

            LastUpdateDate = DateTime.Now;
        }

        public void AddView() => View++;

        public void ChangeStatus(ArticleStatus status,string why)
        {
            Status = status;
            StatusDescriber = why;
        }
    }
}