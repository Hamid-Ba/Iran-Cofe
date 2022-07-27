using IranCafe.Domain.CafeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.CafeAgg
{
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Logo).HasMaxLength(200).IsRequired();
            builder.Property(p => p.ShortDesc).HasMaxLength(250);

            builder.HasMany(m => m.Items).WithOne(c => c.Category).HasForeignKey(f => f.CategoryId);
        }
    }
}