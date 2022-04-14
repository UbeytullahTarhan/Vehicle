

using CaseVehicle.Bll;
using CaseVehicle.Dal.Abstract;
using CaseVehicle.Dal.Concrete.Entityframework.Context;
using CaseVehicle.Dal.Concrete.Entityframework.Repository;
using CaseVehicle.Dal.Concrete.Entityframework.UnitOfWork;
using CaseVehicle.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseVehicle.WebApi
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
            services.AddScoped<DbContext, VehicleDBContext>();
           /* services.AddDbContext<VehicleDBContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("SqlServer"), sqlOpt =>
                {
                    sqlOpt.MigrationsAssembly("CaseVehicle.Dal");
                });
            });*/

            services.AddScoped<ICarService, CarManager>();
            services.AddScoped<IBusService, BuseManager>();
            services.AddScoped<IBoatService, BoatManager>();


            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBuseRepository, BuseRepository>();
            services.AddScoped<IBoatRepository, BoatRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CaseVehicle.WebApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CaseVehicle.WebApi v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
