namespace api
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DoaminService = Application.application.services.car;
    using ApplicationService = Domain.domain.services.car;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Esta encargado de mapear y realizar la inyecci�n dependencias. 
    /// Nota: Solo se indica la interfaz con la clase que se implementan directamente, no las interfaces que se pasa por el constructor. 
    /// Lo aterior es la menera que se construye las intancias a las clases de forma automatica.
    /// </summary>
    public class NativeInjectorBootStrapper
    {
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
            //Proporciona los Cors para aceptar las peticiones de un origen diferente a la URL que expone el API
            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod());
            });

            //Entrada unica para la configuración
            services.AddSingleton(configuration);

            // Application
            services.AddScoped<DoaminService.ICarService, DoaminService.CarService>();

            // Domain
            services.AddScoped<ApplicationService.ICarService, ApplicationService.CarService>();

            //Infrastructure
            services.AddScoped<Domain.repositories.contracts.car.ICarRepository, Infrastructure.repositories.car.CarRepository>();

            //Context Infrastructure
            services.AddDbContext<CarContext>(options => options.UseSqlServer(configuration.GetConnectionString("CarConnection")));
        }
    }
}