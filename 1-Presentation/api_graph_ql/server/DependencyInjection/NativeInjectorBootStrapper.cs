namespace server
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using DoaminService=Application.application.services.car;
    using ApplicationService=Domain.domain.services.car;
    using Infrastructure;
    using Microsoft.EntityFrameworkCore;
    using Issues.Services;
    using Issues.Schemas;
    using GraphQL;
    using GraphQL.Server.Transports.AspNetCore;
    using GraphQL.Server.Transports.WebSockets;

    /// <summary>
    /// Esta encargado de mapear y realizar la inyección dependencias. 
    /// Nota: Solo se indica la interfaz con la clase que se implementan directamente, no las interfaces que se pasa por el constructor. 
    /// Lo aterior es la menera que se construye las intancias a las clases de forma automatica.
    /// </summary>
    public class NativeInjectorBootStrapper
    {
        public void RegisterServices(IServiceCollection services, IConfigurationRoot configuration)
        {
               ////////////////////////////////////////// 
              /////////////////DDD////////////////////// 
             //////////////////////////////////////////
            // Application
            services.AddSingleton<Issues.Services.ICarService, Issues.Services.CarService>();
            services.AddSingleton<DoaminService.ICarService, DoaminService.CarService>();
            // Domain
            services.AddSingleton<ApplicationService.ICarService, ApplicationService.CarService>();
            // Infrastructure
            services.AddSingleton<Domain.repositories.contracts.car.ICarRepository, Infrastructure.repositories.car.CarRepository>();
              ////////////////////////////////////////// 
             /////////////////GraphQL////////////////// 
            //////////////////////////////////////////
            services.AddSingleton<IIssueService, IssueService>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IssueType>();
            services.AddSingleton<UserType>();
            services.AddSingleton<CarType>();
            services.AddSingleton<IssueStatusesEnum>();
            services.AddSingleton<IssuesQuery>();
            services.AddSingleton<IssuesSchema>();
            services.AddSingleton<CarCreateInputType>();
            services.AddSingleton<CarUpdateInputType>();            
            services.AddSingleton<CarMutation>(); 
            //WebSocket
            services.AddSingleton<CarStatusesEnum>();
            services.AddSingleton<CarSubscription>();
            services.AddSingleton<CarEventType>();
            services.AddSingleton<ICarEventService, CarEventService>();
            //END
            services.AddSingleton<IDependencyResolver>(c => new FuncDependencyResolver(type => c.GetRequiredService(type)));
            services.AddGraphQLHttp();
            services.AddGraphQLWebSocket<IssuesSchema>();
        }
    }
}