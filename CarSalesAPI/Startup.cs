using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CarSales.Data.Database;
using CarSales.Data.Models;
using CarSales.Data.Repository.v1;
using CarSales.Domain.Command.v1;
using CarSales.Domain.Query.v1;
using CarSales.Domain.ViewModel.v1;
using CarSales.DomainLogic.Handlers.v1;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoWrapper;
using CarSalesAPI.Models;

namespace CarSalesAPI
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

            services.AddControllers();

            services.AddDbContext<DBContext>(options => options.UseSqlServer(Configuration.GetConnectionString("CarDBConnection")));


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Car Sales API",
                    Description = "Car Sales API",
                    Version = "V1"
                });

                var fileName = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var filePath = Path.Combine(AppContext.BaseDirectory, fileName);
                options.IncludeXmlComments(filePath);
            });

            services.AddMediatR(typeof(GetCarListQuery).Assembly);


            services.AddTransient<IDataRepository<Car>, CarRepository>();
            services.AddTransient<IDataRepository<VehicleType>, VehicleTypeRepository>();
            services.AddTransient<IDataRepository<BodyType>, BodyTypeRepository>();

            services.AddTransient<IRequestHandler<AddCarCommand, bool>, AddCarCommandHandler>();
            services.AddTransient<IRequestHandler<DeleteCarCommand, bool>, DeleteCarCommandHandler>();
            services.AddTransient<IRequestHandler<UpdateCarCommand, bool>, UpdateCarCommandHandler>();

            services.AddTransient<IRequestHandler<GetCarByIdQuery, CarDetail>, GetCarByIdHandler>();
            services.AddTransient<IRequestHandler<GetCarListQuery, IEnumerable<CarDetail>>, GetCarListQueryHandler>();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
            options.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());


            app.UseApiResponseAndExceptionWrapper<MapResponseObject>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Car Sales API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}