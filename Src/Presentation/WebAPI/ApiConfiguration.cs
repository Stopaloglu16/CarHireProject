using Application.Common.Interfaces;
using Application.Repositories;
using CarHire.Services.Branchs;
using CarHire.Services.CarBrands;
using CarHire.Services.CarExtras;
using CarHire.Services.CarModelService;
using CarHire.Services.Cars;
using CarHire.Services.Users;
using CarHire.Services.WebMenus;
using CarHireInfrastructure.Repositories.BranchRepos;
using CarHireInfrastructure.Repositories.CarBrandRepos;
using CarHireInfrastructure.Repositories.CarExtraRepos;
using CarHireInfrastructure.Repositories.CarHireRepos;
using CarHireInfrastructure.Repositories.CarModelRepos;
using CarHireInfrastructure.Repositories.CarRepos;
using CarHireInfrastructure.Repositories.UserAuth;
using CarHireInfrastructure.Repositories.UserRepos;
using CarHireInfrastructure.Repositories.WebMenuRepos;
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
