using Framework.Domain;

namespace IranCafe.Domain.CafeAgg
{
    public class Gallery : EntityBase
	{
        public Guid CafeId { get;private set; }
        public string? ImageUrl { get;private set; }
        public string? ImageName { get;private set; }
        public string? FolderPath { get;private set; }

        public Cafe? Cafe { get;private set; }

        public Gallery(Guid cafeId, string? imageUrl, string? imageName, string? folderPath)
        {
            CafeId = cafeId;
            ImageUrl = imageUrl;
            ImageName = imageName;
            FolderPath = folderPath;
        }
    }
}