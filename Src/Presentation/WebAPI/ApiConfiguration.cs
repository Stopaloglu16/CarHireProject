using Application.Common.Interfaces;
using Application.Repositories;
using CarHire.Services.Branchs;
using CarHire.Services.CarBrands;
using CarHire.Services.CarExtras;
using CarHire.Services.CarModelService;
using CarHire.Services.Cars;
using CarHire.Services.Users;
using CarHire.Services.WebMenus;
using Infrastructure.Repositories.AddressRepos;
using Infrastructure.Repositories.BranchRepos;
using Infrastructure.Repositories.CarBrandRepos;
using Infrastructure.Repositories.CarExtraRepos;
using Infrastructure.Repositories.CarHireRepos;
using Infrastructure.Repositories.CarModelRepos;
using Infrastructure.Repositories.CarRepos;
using Infrastructure.Repositories.UserAuth;
using Infrastructure.Repositories.UserRepos;
using Infrastructure.Repositories.WebMenuRepos;
using WebAPI.Services;

namespace WebAPI
{

    public static class ApiConfiguration
    {
        public static IServiceCollection AddBlazorServices(this IServiceCollection services)
        {

            services.AddScoped<IUserLoginRepository, UserLoginRepository>();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICarExtraService, CarExtraService>();
            services.AddScoped<ICarBrandService, CarBrandService>();
            services.AddScoped<ICarModelService, CarModelService>();
            services.AddScoped<ICarService, CarService>();
            services.AddScoped<IWebMenuService, WebMenuService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarHireRepository, CarHireRepository>();
            services.AddScoped<ICarExtraRepository, CarExtraRepository>();
            services.AddScoped<ICarBrandRepository, CarBrandRepository>();
            services.AddScoped<ICarModelRepository, CarModelRepository>();
            services.AddScoped<IWebMenuRepository, WebMenuRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
