using System;
using IranCafe.Domain.CafeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.CafeAgg
{
    public class CafeMapping : IEntityTypeConfiguration<Cafe>
    {
        public void Configure(EntityTypeBuilder<Cafe> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.UniqueCode).IsRequired().HasMaxLength(6);
            builder.Property(p => p.FaTitle).IsRequired().HasMaxLength(85);
            builder.Property(p => p.EnTitle).IsRequired().HasMaxLength(85);
            builder.Property(p => p.Phone).IsRequired().HasMaxLength(11);
            builder.Property(p => p.Slug).IsRequired().HasMaxLength(185);
            builder.Property(p => p.Street).IsRequired().HasMaxLength(200);
            builder.Property(p => p.ShortDesc).IsRequired().HasMaxLength(500);
            builder.Property(p => p.Desc).IsRequired();

            builder.HasMany(u => u.Users)
                .WithOne(c => c.Cafe)
                .HasForeignKey(f => f.CafeId);
        }
    }
}