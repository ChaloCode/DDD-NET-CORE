using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using GraphQL;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.WebSockets;
using Issues.Services;
using Issues.Schemas;
//DDD
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace server
{
    /// <summary>
    /// Clase de arranque del proyecto
    /// </summary>
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }
   
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            RegisterServices(services);
        }

        private void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            new NativeInjectorBootStrapper().RegisterServices(services, Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Se requiere para que carge cliente de GraphQL donde se prueba la API
            app.UseDefaultFiles();
            app.UseStaticFiles();
            //Se requiere para que GraphQL resuelva WebSocket
            app.UseWebSockets();
            app.UseGraphQLWebSocket<IssuesSchema>(new GraphQLWebSocketsOptions());
            //Se requiere para que GraphQL resuelva peticiones HTTP
            app.UseGraphQLHttp<IssuesSchema>(new GraphQLHttpOptions());
        }
    }
}
