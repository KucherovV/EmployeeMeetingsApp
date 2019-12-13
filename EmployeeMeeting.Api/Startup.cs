using AutoMapper;
using EmployeeMeeting.Api.Filters;
using EmployeeMeeting.Api.Mappings;
using EmployeeMeeting.Domain.Core;
using EmployeeMeeting.Domain.Interfaces;
using EmployeeMeeting.Infrastructure.Data;
using EmployeeMeeting.Infrastructure.Data.UserStores;
using EmployeeMeeting.Services.Data;
using EmployeeMeeting.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
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

            services.AddScoped<IRepository<Country, int>, CountryRepository>();
            services.AddScoped<IRepository<City, int>, CityRepository>();

            services.AddScoped(typeof(ICountryService), typeof(CountryService));
            services.AddScoped(typeof(ICityService), typeof(CityService));

            services.AddTransient<IUserStore<ApplicationUser>, UserStore>();
            services.AddTransient<IRoleStore<ApplicationRole>, RoleStore>();

            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddDefaultTokenProviders();

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new CityMappingProfile());
                mc.AddProfile(new CountryMappingProfile());
                mc.AddProfile(new UserMappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(ValidateModelStateAttribute));
            });

            services.AddSwaggerGen(c=> {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            FastCrudEntityRegistration.Register();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
