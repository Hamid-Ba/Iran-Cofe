using Framework.Application;
using Framework.Domain.Cafe;

namespace IranCafe.Application.Contract.BlogAgg
{
    public class ArticleDto : EntityBaseDto
    {
        public Guid CafeId { get; set; }
        public string CafeCode { get; set; }
        public string Title { get; set; }
        public string PictureName { get; set; }
        public DateTime PublishDate { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
        public long View { get; set; }
        public string PersianCreationDate { get; set; }
        public string PersianPublishDate { get; set; }
        public ArticleStatus Status { get; set; }
        public string StatusDescriber { get; set; }
    }

    public class CreateArticleDto
    {
        public Guid CafeId { get; set; }
        public string Title { get; set; }
        public string PictureName { get; set; }
        public DateTime PublishDate { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string MetaDescription { get; set; }
    }

    public class EditArticleDto : CreateArticleDto 
    {
        public Guid Id { get; set; }
    }

    public class ChangeArticleStatus
    {
        public Guid Id { get; set; }
        public ArticleStatus Status { get; set; }
        public string? Why { get; set; }
    }

    public class FilterArticleDto : BaseFilterParam
    {
        public string? Code { get; set; }
    }

    public class PaginatedArticlesDto : BaseFilter<ArticleDto, FilterArticleDto> { }
}