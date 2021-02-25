using System;
using System.IO;
using System.Reflection;
using GloboTicket.Services.ShoppingBasket.DbContexts;
using GloboTicket.Services.ShoppingBasket.Repositories;
using GloboTicket.Services.ShoppingBasket.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace GloboTicket.Services.ShoppingBasket
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
            services.AddDbContext<ShoppingBasketDbContext>(it => it.UseSqlite(_configuration.GetConnectionString("ShoppingBasketDbContext")));

            services.AddHttpClient<IEventCatalogService, HttpEventCatalogService>(it =>
            {
                it.BaseAddress = new Uri(_configuration["Services:EventCatalogService:Uri"]);
            });

            services.AddScoped<IBasketRepository, EFBasketRepository>();

            services.AddScoped<IEventRepository, EFEventRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddSwaggerGen(it =>
            {
                it.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Shopping Basket",
                    Version = "v1"
                });

                it.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "GloboTicket.Services.ShoppingBasket.xml"));
            });

            services.AddControllers(it =>
            {
                it.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                it.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(it =>
            {
                it.SwaggerEndpoint("/swagger/v1/swagger.json", "Shopping Basket");

                it.RoutePrefix = string.Empty;
            });

            app.UseReDoc(it =>
            {
                it.SpecUrl("/swagger/v1/swagger.json");

                it.RoutePrefix = "api-reference";
            });

            app.UseRouting();

            app.UseEndpoints(it => it.MapControllers());
        }
    }
}
