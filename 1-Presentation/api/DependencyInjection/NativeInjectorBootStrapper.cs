namespace api
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DoaminService=Application.application.services.car;
    using ApplicationService=Domain.domain.services.car;

    public class NativeInjectorBootStrapper
    {
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.AddSingleton(configuration);

            // Application
            services.AddScoped<DoaminService.ICarService, DoaminService.CarService>();

            // Domain
            services.AddScoped<ApplicationService.ICarService, ApplicationService.CarService>();
        }
    }
}