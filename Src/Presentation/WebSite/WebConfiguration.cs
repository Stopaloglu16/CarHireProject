using Application.Aggregates.BranchAggregate.Commands.Create;
using Application.Aggregates.BranchAggregate.Commands.Update;
using Application.Aggregates.BranchAggregate.Queries;
using Application.Aggregates.CarAggregate.Commands.Create;
using Application.Aggregates.CarAggregate.Commands.Update;
using Application.Aggregates.CarAggregate.Queries;
using Application.Aggregates.CarExtraAggregate.Queries;
using Application.Aggregates.CarHireAggregate.Commands.Create;
using Application.Aggregates.CarHireAggregate.Queries;
using Application.Aggregates.CarModelAggregate.Commands.Create;
using Application.Aggregates.CarModelAggregate.Commands.Update;
using Application.Aggregates.CarModelAggregate.Queries;
using Domain.Entities.UserAggregate;
using Domain.Utilities;
using WebSite.Handlers;
using WebSite.Services;

namespace WebSite
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddBlazorServices(this IServiceCollection services)
        {

            services.AddHttpClient<IWebApiService<User, User>, WebApiService<User, User>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<BranchDto, BranchDto>, WebApiService<BranchDto, BranchDto>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<CreateBranchRequest, CreateBranchResponse>, WebApiService<CreateBranchRequest, CreateBranchResponse>>().AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddHttpClient<IWebApiService<UpdateBranchRequest, UpdateBranchResponse>, WebApiService<UpdateBranchRequest, UpdateBranchResponse>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<CreateCarModelRequest, CreateCarModelResponse>, WebApiService<CreateCarModelRequest, CreateCarModelResponse>>().AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddHttpClient<IWebApiService<UpdateCarModelRequest, UpdateCarModelResponse>, WebApiService<UpdateCarModelRequest, UpdateCarModelResponse>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<CarDto, CarDto>, WebApiService<CarDto, CarDto>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<CreateCarRequest, CreateCarResponse>, WebApiService<CreateCarRequest, CreateCarResponse>>().AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddHttpClient<IWebApiService<UpdateCarRequest, UpdateCarResponse>, WebApiService<UpdateCarRequest, UpdateCarResponse>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<CarExtraDto, CarExtraDto>, WebApiService<CarExtraDto, CarExtraDto>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<CarModelDto, CarModelDto>, WebApiService<CarModelDto, CarModelDto>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<CreateCarHireCommand, int>, WebApiService<CreateCarHireCommand, int>>().AddHttpMessageHandler<ValidateHeaderHandler>();


            services.AddHttpClient<IWebApiService<CarHireCarDto, CarHireCarDto>, WebApiService<CarHireCarDto, CarHireCarDto>>().AddHttpMessageHandler<ValidateHeaderHandler>();
            services.AddHttpClient<IWebApiService<CarHireBookDisplay, CarHireBookDisplay>, WebApiService<CarHireBookDisplay, CarHireBookDisplay>>().AddHttpMessageHandler<ValidateHeaderHandler>();

            services.AddHttpClient<IWebApiService<SelectListItem, SelectListItem>, WebApiService<SelectListItem, SelectListItem>>().AddHttpMessageHandler<ValidateHeaderHandler>();


            //IMenuService

            return services;
        }
    }
}
