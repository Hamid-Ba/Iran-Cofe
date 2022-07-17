using IranCafe.Application.AccountAgg;
using IranCafe.Application.Contract.AccountAgg.Contracts;
using IranCafe.Application.Contract.UserAgg.Contracts;
using IranCafe.Application.UserAgg;
using IranCafe.Domain.AccountAgg.Contracts;
using IranCafe.Domain.CafeAgg.Contracts;
using IranCafe.Domain.UserAgg;
using IranCafe.Infrastructure.EfCore;
using IranCafe.Infrastructure.EfCore.Repositories.AccountAgg;
using IranCafe.Infrastructure.EfCore.Repositories.CafeAgg;
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

            #region AccountAgg

            service.AddTransient<IOperatorRepository, OperatorRepository>();
            service.AddTransient<IOperatorApplication, OperatorApplication>();

            #endregion

            #region UserAgg

            service.AddTransient<IUserRepository, UserRepository>();
            service.AddTransient<IUserApplication, UserApplication>();

            #endregion

            #region CafeAgg

            service.AddTransient<ICafeRepository, CafeRepository>();

            #endregion


        }
    } 
}