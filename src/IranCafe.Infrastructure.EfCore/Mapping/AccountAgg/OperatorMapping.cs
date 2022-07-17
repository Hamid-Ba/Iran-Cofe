using IranCafe.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.AccountAgg
{
    public class OperatorMapping : IEntityTypeConfiguration<Operator>
    {
        public void Configure(EntityTypeBuilder<Operator> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.Mobile).HasMaxLength(11).IsRequired();
            builder.Property(p => p.FullName).HasMaxLength(50).IsRequired();
        }
    }
}