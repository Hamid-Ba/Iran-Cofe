﻿using IranCafe.Application.Contract.UserAgg;
using IranCafe.Application.UserAgg;
using IranCafe.Domain.UserAgg;
using IranCafe.Infrastructure.EfCore;
using IranCafe.Infrastructure.EfCore.Repositories.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IranCafe.Infrastructure.Configuration
{
    public static class CafeBootstrapper
	{
		public static void Configure(IServiceCollection service,string connectionString)
        {
            #region Configure Context
            service.AddDbContext<CafeContext>(option => option.UseSqlServer(connectionString));
            #endregion

            #region UserAgg

            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IUserApplication, UserApplication>();

            #endregion



        }
    } 
}