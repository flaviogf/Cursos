using System.Reflection;
using AutoMapper;
using CourseLibrary.Api.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Serialization;

namespace CourseLibrary.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(it => it.UseSqlite(_configuration.GetConnectionString("Default")));

            services.AddScoped<ICourseLibraryRepository, CourseLibraryRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services
                .AddControllers(it =>
                {
                    it.ReturnHttpNotAcceptable = true;
                })
                .AddNewtonsoftJson(it =>
                {
                    it.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                })
                .AddXmlDataContractSerializerFormatters();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(it => it.MapControllers());
        }
    }
}
