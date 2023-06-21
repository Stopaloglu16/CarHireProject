using Domain.Entities.UserAggregate;
using WebUI.Handlers;
using WebUI.Services;

namespace WebUI
{
    public static class WebConfiguration
    {
        public static IServiceCollection AddBlazorServices(this IServiceCollection services)
        {

            
            services.AddHttpClient<IWebApiService<User, User>, WebApiService<User, User>>().AddHttpMessageHandler<ValidateHeaderHandler>();


            return services;
        }
    }
}
