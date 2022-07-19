using IranCafe.Domain.AccountAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.UserAgg;
using IranCafe.Infrastructure.EfCore.Mapping.UserAgg;
using Microsoft.EntityFrameworkCore;

namespace IranCafe.Infrastructure.EfCore
{
    public class CafeContext : DbContext
    {
        public CafeContext(DbContextOptions<CafeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(s => s.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Cascade;

            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<User>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Cafe>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Operator>().HasQueryFilter(q => !q.IsDelete);

            //Seed Operator
            //modelBuilder.Entity<Operator>().HasData(new Operator("حمید بلال زاده", "09151498722", hashpassword););
        }

        #region AccountAgg

        public DbSet<Operator> Operators { get; set; }

        #endregion

        #region UserAgg

        public DbSet<User> Users { get; set; }

        #endregion

        #region CafeAgg

        public DbSet<Cafe> Cafes { get; set; }

        #endregion
    }
}