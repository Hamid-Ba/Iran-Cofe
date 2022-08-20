using Framework.Domain;
using IranCafe.Application.Contract.BlogAgg;

namespace IranCafe.Domain.BlogAgg.Contracts
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<ArticleDto> GetBy(string slug);
        Task<IEnumerable<ArticleDto>> GetAll();
        Task<PaginatedArticlesDto> GetPaginated(FilterArticleDto filter);
    }
}