using IranCafe.Application.AccountAgg;
using IranCafe.Application.CafeAgg;
using IranCafe.Application.Contract.AccountAgg.Contracts;
using IranCafe.Application.Contract.CafeAgg.Contracts;
using IranCafe.Application.Contract.PlanAgg.Contracts;
using IranCafe.Application.Contract.SiteEntities.Contracts;
using IranCafe.Application.Contract.UserAgg.Contracts;
using IranCafe.Application.PlanAgg;
using IranCafe.Application.SiteEntities;
using IranCafe.Application.UserAgg;
using IranCafe.Domain.AccountAgg.Contracts;
using IranCafe.Domain.CafeAgg.Contracts;
using IranCafe.Domain.EventAgg.Contracts;
using IranCafe.Domain.PlanAgg.Contracts;
using IranCafe.Domain.SiteEntities.Contracts;
using IranCafe.Domain.UserAgg;
using IranCafe.Infrastructure.EfCore;
using IranCafe.Infrastructure.EfCore.Repositories.AccountAgg;
using IranCafe.Infrastructure.EfCore.Repositories.CafeAgg;
using IranCafe.Infrastructure.EfCore.Repositories.EventAgg;
using IranCafe.Infrastructure.EfCore.Repositories.PlanAgg;
using IranCafe.Infrastructure.EfCore.Repositories.SiteEntities;
using IranCafe.Infrastructure.EfCore.Repositories.UserAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace IranCafe.Infrastructure.Configuration
{
    public static class CafeBootstrapper
    {
        public static void Configure(IServiceCollection service, string connectionString)
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
            service.AddTransient<ICafeApplication, CafeApplication>();

            service.AddTransient<IGalleryRepository, GalleryRepository>();
            service.AddTransient<IGalleryApplication, GalleryApplication>();

            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<ICategoryApplication, CategoryApplication>();

            service.AddTransient<IMenuItemRepository, MenuItemRepository>();
            service.AddTransient<IMenuItemApplication, MenuItemApplication>();

            service.AddTransient<IReservationRepository, ReservationRepository>();
            service.AddTransient<IReservationApplication, ReservationApplication>();

            #endregion

            #region Event

            service.AddTransient<ICustomerClubRepository, CustomerClubRepository>();
            service.AddTransient<ICustomerClubUsersRepository, CustomerClubUsersRepository>();

            #endregion

            #region Subscriptions

            service.AddTransient<IPlanRepository, PlanRepository>();
            service.AddTransient<IPlanApplication, PlanApplication>();

            #endregion

            #region SiteEntities

            service.AddTransient<ICityRepository, CityRepository>();
            service.AddTransient<ICityApplication, CityApplication>();

            service.AddTransient<ISettingRepository, SettingRepository>();
            service.AddTransient<ISettingApplication, SettingApplication>();

            service.AddTransient<IProvinceRepository, ProvinceRepository>();
            service.AddTransient<IProvinceApplication, ProvinceApplication>();

            #endregion
        }
    }
}