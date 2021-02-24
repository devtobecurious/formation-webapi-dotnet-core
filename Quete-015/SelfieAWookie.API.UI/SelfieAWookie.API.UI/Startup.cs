using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SelfieAWookies.Core.Selfies.Infrastructures.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SelfieAWookies.Core.Selfies.Domain;
using SelfieAWookies.Core.Selfies.Infrastructures.Repositories;
using SelfieAWookie.API.UI.ExtensionMethods;
using Microsoft.AspNetCore.Identity;
using SelfieAWookies.Core.Selfies.Infrastructures.Loggers;
using SelfieAWookie.API.UI.Middlewares;

namespace SelfieAWookie.API.UI
{
    public class Startup
    {
        #region Constructors
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        #region Public methods
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<SelfiesContext>(options =>
            {
                options.UseSqlServer(this.Configuration.GetConnectionString("SelfiesDatabase"), sqlOptions => {});
            });
            services.AddDefaultIdentity<IdentityUser>(options =>
            {
                // options.SignIn.RequireConfirmedEmail = true;
            }).AddEntityFrameworkStores<SelfiesContext>();

            services.AddCustomOptions(this.Configuration);
            services.AddInjections();
            services.AddCustomSecurity(this.Configuration);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SelfieAWookie.API.UI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddProvider(new CustomLoggerProvider());

            app.UseMiddleware<LogRequestMiddleware>();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SelfieAWookie.API.UI v1"));

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(SecurityMethods.DEFAULT_POLICY_2);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        #endregion

        #region Properties
        public IConfiguration Configuration { get; }
        #endregion
    }
}
