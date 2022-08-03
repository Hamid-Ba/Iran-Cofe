using IranCafe.Domain.CafeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IranCafe.Infrastructure.EfCore.Mapping.CafeAgg
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.ReserveHourStr).IsRequired();
            builder.Property(p => p.ReserveDateStr).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(11).IsRequired();

            builder.HasOne(u => u.User).WithMany(r => r.Reservations).HasForeignKey(f => f.UserId);
            builder.HasOne(u => u.Cafe).WithMany(r => r.Reservations).HasForeignKey(f => f.CafeId);
        }
    }
}