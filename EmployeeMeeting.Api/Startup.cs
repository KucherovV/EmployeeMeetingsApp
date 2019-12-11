using AutoMapper;
using EmployeeMeeting.Api.Filters;
using EmployeeMeeting.Api.Mappings;
using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;
using EmployeeMeeting.Infrastructure.Data;
using EmployeeMeeting.Services.Data;
using EmployeeMeeting.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeMeeting.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddTransient<IDbConnection>((sp) => new SqlConnection(connectionString));
            services.AddScoped(typeof(IDatabaseConnectionFactory), typeof(DatabaseConnectionFactory));

            services.AddScoped<IRepository<Country>, CountryRepository>();
            services.AddScoped<IRepository<City>, CityRepository>();

            services.AddScoped(typeof(ICountryService), typeof(CountryService));
            services.AddScoped(typeof(ICityService), typeof(CityService));

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CityMappingProfile());
                mc.AddProfile(new CountryMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
