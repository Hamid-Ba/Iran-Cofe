using IranCafe.Domain.AccountAgg;
using IranCafe.Domain.CafeAgg;
using IranCafe.Domain.PlanAgg;
using IranCafe.Domain.SiteEntities;
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
                relationship.DeleteBehavior = DeleteBehavior.Restrict;

            var assembly = typeof(UserMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            modelBuilder.Entity<User>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Plan>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Cafe>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<City>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Gallery>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Operator>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Province>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<MenuItem>().HasQueryFilter(q => !q.IsDelete);
            modelBuilder.Entity<Reservation>().HasQueryFilter(q => !q.IsDelete);

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
        public DbSet<Gallery> Galleries { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        #endregion

        #region Plan

        public DbSet<Plan> Plans { get; set; }

        #endregion

        #region SiteEntities

        public DbSet<City> City { get; set; }
        public DbSet<Province> Provinces { get; set; }

        #endregion
    }
}