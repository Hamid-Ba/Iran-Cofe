using Framework.Application;
using IranCafe.Application.Contract.BlogAgg;
using IranCafe.Application.Contract.BlogAgg.Contracts;
using IranCafe.Domain.BlogAgg;
using IranCafe.Domain.BlogAgg.Contracts;

namespace IranCafe.Application.BlogAgg
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;

        public ArticleApplication(IArticleRepository articleRepository) => _articleRepository = articleRepository;

        public async Task<OperationResult> ChangeStatus(ChangeArticleStatus command)
        {
            OperationResult result = new();

            var article = await _articleRepository.GetEntityByIdAsync(command.Id);
            if (article is null) return result.Failed(ApplicationMessage.NotExist);

            article.ChangeStatus(command.Status, command.Why!);
            await _articleRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Create(CreateArticleDto command)
        {
            OperationResult result = new();

            if (_articleRepository.Exists(a => a.Slug == command.Slug))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var slug = command.Slug.Slugify();
            var article = new Article(command.CafeId, command.Title, command.PictureName, command.PublishDate, command.ShortDescription,
                command.Description, slug, command.Keywords, command.MetaDescription);

            await _articleRepository.AddEntityAsync(article);
            await _articleRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Delete(Guid id)
        {
            OperationResult result = new();

            var article = await _articleRepository.GetEntityByIdAsync(id);
            if (article is null) return result.Failed(ApplicationMessage.NotExist);

            article.Delete();
            await _articleRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditArticleDto command)
        {
            OperationResult result = new();

            var article = await _articleRepository.GetEntityByIdAsync(command.Id);
            if (article is null) return result.Failed(ApplicationMessage.NotExist);
            if (_articleRepository.Exists(a => a.Slug == command.Slug && a.Id != command.Id))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var slug = command.Slug.Slugify();
            article.Edit(command.Title, command.PictureName, command.PublishDate, command.ShortDescription,
                command.Description, slug, command.Keywords, command.MetaDescription);

            return result.Succeeded();
        }

        public async Task<IEnumerable<ArticleDto>> GetAll() => await _articleRepository.GetAll();

        public async Task<ArticleDto> GetBy(string slug) => await _articleRepository.GetBy(slug);
        
        public async Task<PaginatedArticlesDto> GetPaginated(FilterArticleDto filter) => await _articleRepository.GetPaginated(filter);

        public async Task<OperationResult> Viwed(Guid id)
        {
            OperationResult result = new();

            var article = await _articleRepository.GetEntityByIdAsync(id);
            if (article is null) return result.Failed(ApplicationMessage.NotExist);

            article.AddView();

            return result.Succeeded();
        }
    }
}