using IranCafe.Domain.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.UserAgg
{
    public class UserMapping : IEntityTypeConfiguration<User>
	{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.PhoneCode).HasMaxLength(6);
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();
            builder.Property(p => p.FullName).HasMaxLength(125).IsRequired();

            builder.HasOne(c => c.Cafe)
                .WithMany(u => u.Users)
                .HasForeignKey(f => f.CafeId);

            builder.HasMany(c => c.Clubs)
                .WithOne(c => c.User)
                .HasForeignKey(f => f.CustomerClubId);
        }
    }
}