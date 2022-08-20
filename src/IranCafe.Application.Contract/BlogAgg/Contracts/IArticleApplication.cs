using Framework.Application;

namespace IranCafe.Application.Contract.BlogAgg.Contracts
{
    public interface IArticleApplication
    {
        Task<ArticleDto> GetBy(string slug);
        Task<OperationResult> Viwed(Guid id);
        Task<OperationResult> Delete(Guid id);
        Task<IEnumerable<ArticleDto>> GetAll();
        Task<OperationResult> Edit(EditArticleDto command);
        Task<OperationResult> Create(CreateArticleDto command);
        Task<OperationResult> ChangeStatus(ChangeArticleStatus command);
        Task<PaginatedArticlesDto> GetPaginated(FilterArticleDto filter);
    }
}