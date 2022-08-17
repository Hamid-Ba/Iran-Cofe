using IranCafe.Domain.EventAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.EventAgg
{
    public class CustomerClubUsersMapping : IEntityTypeConfiguration<CustomerClubUsers>
    {
        public void Configure(EntityTypeBuilder<CustomerClubUsers> builder)
        {
            builder.HasKey(k => new { k.UserId, k.CustomerClubId });

            builder.HasOne(u => u.User)
                .WithMany(c => c.Clubs)
                .HasForeignKey(u => u.UserId);

            builder.HasOne(u => u.CustomerClubs)
                .WithMany(c => c.Customers)
                .HasForeignKey(u => u.CustomerClubId);
        }
    }
}
