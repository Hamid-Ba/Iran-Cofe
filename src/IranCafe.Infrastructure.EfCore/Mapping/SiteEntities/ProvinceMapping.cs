using IranCafe.Domain.SiteEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.SiteEntities
{
    internal class ProvinceMapping : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(85).IsRequired();

            builder.HasMany(c => c.Cities).WithOne(p => p.Province).HasForeignKey(f => f.ProvinceId);
        }
    }
}