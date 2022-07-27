using Framework.Application;
using IranCafe.Application.Contract.CafeAgg;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.CafeAgg.Contracts;

namespace IranCafe.Application.CafeAgg
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public async Task<OperationResult> Create(CreateCategoryDto command)
        {
            OperationResult result = new();

            if (_categoryRepository.Exists(c => c.Title == command.Title))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var slug = command.Slug!.Slugify();

            var folderName = $"category\\{slug}";
            var logo = Uploader.ImageUploader(command.LogoFile!, folderName, null!);

            var category = new Category(command.Title!, slug, logo, command.ShortDesc!);

            await _categoryRepository.AddEntityAsync(category);
            await _categoryRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<OperationResult> Edit(EditCategoryDto command)
        {
            OperationResult result = new();

            var category = await _categoryRepository.GetEntityByIdAsync(command.Id);

            if (category is null) return result.Failed(ApplicationMessage.NotExist);
            if (_categoryRepository.Exists(c => c.Title == command.Title && c.Id != command.Id))
                return result.Failed(ApplicationMessage.DuplicatedModel);

            var slug = command.Slug!.Slugify();

            var folderName = $"category\\{slug}";
            var logo = Uploader.ImageUploader(command.LogoFile!, folderName, category.Logo!);

            category.Edit(command.Title!, slug, logo, command.ShortDesc!);
            await _categoryRepository.SaveChangesAsync();

            return result.Succeeded();
        }

        public async Task<IEnumerable<CategoryDto>> GetAllBy() => await _categoryRepository.GetAllBy();

        public async Task<EditCategoryDto> GetDetailForEditBy(Guid id) => await _categoryRepository.GetDetailForEditBy(id);
    }
}