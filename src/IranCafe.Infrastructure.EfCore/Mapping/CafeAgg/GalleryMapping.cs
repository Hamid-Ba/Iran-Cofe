using IranCafe.Domain.CafeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.CafeAgg
{
    internal class GalleryMapping : IEntityTypeConfiguration<Gallery>
    {
        public void Configure(EntityTypeBuilder<Gallery> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ImageName).HasMaxLength(300).IsRequired();
            builder.Property(p => p.ImageUrl).HasMaxLength(500).IsRequired();

            builder.HasOne(c => c.Cafe)
                .WithMany(g => g.Galleries)
                .HasForeignKey(f => f.CafeId);
        }
    }
}