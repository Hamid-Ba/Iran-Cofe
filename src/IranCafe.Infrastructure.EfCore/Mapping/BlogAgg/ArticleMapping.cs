using IranCafe.Domain.BlogAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.BlogAgg
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(125).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(285).IsRequired();
            builder.Property(p => p.PictureName).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(225).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Keywords).HasMaxLength(225).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(500).IsRequired();

            builder.HasOne(c => c.Cafe).WithMany(a => a.Articles).HasForeignKey(f => f.CafeId);
        }
    }
}