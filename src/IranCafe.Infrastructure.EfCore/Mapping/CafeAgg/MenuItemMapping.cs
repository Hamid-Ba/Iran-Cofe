using IranCafe.Domain.CafeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.CafeAgg
{
    internal class MenuItemMapping : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(100).IsRequired();
            builder.Property(p => p.ShortDesc).HasMaxLength(225).IsRequired();
            builder.Property(p => p.ImageUrl).HasMaxLength(400).IsRequired();
            builder.Property(p => p.Desc).HasMaxLength(1500);

            builder.HasOne(c => c.Cafe).WithMany(m => m.Items).HasForeignKey(f => f.CafeId);
            builder.HasOne(c => c.Category).WithMany(m => m.Items).HasForeignKey(f => f.CategoryId);
        }
    }
}