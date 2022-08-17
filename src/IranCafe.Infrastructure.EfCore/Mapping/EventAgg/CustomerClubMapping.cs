using IranCafe.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.EventAgg
{
    public class CustomerClubMapping : IEntityTypeConfiguration<CustomerClub>
    {
        public void Configure(EntityTypeBuilder<CustomerClub> builder)
        {
            builder.HasKey(k => k.Id);

            //builder.HasOne(c => c.Cafe).WithOne(c => c.Club).HasForeignKey(f => f.);

            builder.HasMany(u => u.Customers)
                .WithOne(c => c.CustomerClubs)
                .HasForeignKey(f => f.UserId);
        }
    }
}