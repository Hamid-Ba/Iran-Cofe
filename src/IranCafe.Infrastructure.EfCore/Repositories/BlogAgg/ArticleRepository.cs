using Framework.Application;
using Framework.Infrastructure;
using IranCafe.Application.Contract.BlogAgg;
using IranCafe.Domain.BlogAgg;
using IranCafe.Domain.BlogAgg.Contracts;
using Microsoft.EntityFrameworkCore;
using Framework.Domain.Cafe;

namespace IranCafe.Infrastructure.EfCore.Repositories.BlogAgg
{
    public class ArticleRepository : Repository<Article>, IArticleRepository
    {
        private readonly CafeContext _context;

        public ArticleRepository(CafeContext context) : base(context) => _context = context;

        public async Task<IEnumerable<ArticleDto>> GetAll() => await _context.Articles.Include(c => c.Cafe).Select(a => new ArticleDto
        {
            Id = a.Id,
            CafeCode = a.Cafe.UniqueCode!,
            CafeId = a.CafeId,
            Title = a.Title,
            Slug = a.Slug,
            PictureName = a.PictureName,
            PersianPublishDate = a.PublishDate.ToFarsi(),
            View = a.View,
            Status = a.Status,
            PersianCreationDate = a.CreationDate.ToFarsi()
        }).AsNoTracking().ToListAsync();

        public async Task<ArticleDto> GetBy(string slug) => (await _context.Articles.Select(a => new ArticleDto
        {
            Id = a.Id,
            CafeId = a.CafeId,
            Slug = a.Slug,
            Title = a.Title,
            PictureName = a.PictureName,
            ShortDescription = a.ShortDescription,
            Description = a.Description,
            PersianPublishDate = a.PublishDate.ToFarsi(),
            PersianCreationDate = a.CreationDate.ToFarsi(),
            Keywords = a.Keywords,
            MetaDescription = a.MetaDescription,
        }).AsNoTracking().FirstOrDefaultAsync(a => a.Slug == slug))!;


        public async Task<PaginatedArticlesDto> GetPaginated(FilterArticleDto filter)
        {
            var data = _context.Articles.Where(a => a.Status == ArticleStatus.Confirmed).Select(a => new ArticleDto
            {
                Id = a.Id,
                Slug = a.Slug,
                PictureName = a.PictureName,
                Title = a.Title,
                ShortDescription = a.ShortDescription,
                PersianPublishDate = a.PublishDate.ToFarsi(),
                PublishDate = a.PublishDate,
            }).AsNoTracking().AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Code)) data = data.Where(a => a.CafeCode == filter.Code);

            var result = new PaginatedArticlesDto()
            {
                FilterParams = filter,
                Data = await data.Skip((filter.PageId - 1) * filter.Take).Take(filter.Take).OrderByDescending(a => a.PublishDate).ToListAsync()
            };
            result.GeneratePaging(data,filter.Take,filter.PageId);

            return result;
        }
    }
}