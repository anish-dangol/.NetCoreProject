using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using VehicleApi.Models;
using VehicleApi.Context;
using System.Reflection;
using System;
using Swashbuckle.AspNetCore.Swagger;
using VehicleApi.Services;
using VehicleApi.Services.Interfaces;
using VehicleApi.Repositories;
using VehicleApi.Repositories.Interfaces;


namespace VehicleApi
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureTransientServices(services);
            ConfigureRepositories(services);

            services.AddDbContext<VehicleApiDbContext>(opt => opt.UseInMemoryDatabase("VehiclesList"));

            
            services.AddCors(c =>  
            {  
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());  
            }); 
            
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddControllers();

            //Swagger Implementation code:
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "Swagger Demo API",
                        Description = "Demo API for showing Swagger",
                        Version = "v1"
                    });
            });

        }

        private static void ConfigureTransientServices(IServiceCollection services)
        {
            services.AddTransient<IVehicleService, VehicleService>();
        }

        private static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddSingleton<IVehicleRepository, VehicleRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            //app.UseMvc();
             app.UseCors(options => options //.WithOrigins("http://localhost:4200")
             .AllowAnyOrigin().
             AllowAnyHeader().
             AllowAnyMethod());


            app.UseMvc();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {                
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
                }
                );
        }
    }
}
