﻿using IranCafe.Domain.UserAgg;
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
        }

        #region UserAgg

        public DbSet<User> Users { get; set; }

        #endregion
    }
}