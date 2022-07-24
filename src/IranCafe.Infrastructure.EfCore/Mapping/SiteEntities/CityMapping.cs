using IranCafe.Domain.SiteEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.SiteEntities
{
    internal class CityMapping : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Title).HasMaxLength(80).IsRequired();

            builder.HasMany(c => c.Cafe).WithOne(c => c.City).HasForeignKey(f => f.CityId);
            builder.HasOne(p => p.Province).WithMany(c => c.Cities).HasForeignKey(f => f.ProvinceId);
        }
    }
}