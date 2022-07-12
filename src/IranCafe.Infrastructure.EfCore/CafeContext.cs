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

            //var assembly = typeof(OperatorMapping).Assembly;
            //modelBuilder.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}