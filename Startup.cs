using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MReportAPI.Data;
using MReportAPI.Data.EFCore;

namespace MReportAPI
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
            services.AddSwaggerGen();
            services.AddCors();
            services.AddDbContext<MReportAPIContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("MReportAPIContext")));
            services.AddScoped<EFCorePatientRepository>();
            services.AddScoped<EFCoreChannellingRepository>();
            services.AddScoped<EFCoreDoctorRepository>();
            services.AddScoped<EFCoreHospitalRepository>();
            services.AddScoped<EFCoreReportRepository>();
            services.AddScoped<EFCoreSuperAdminRepository>();
            services.AddScoped<EFCoreVaccineRepository>();
           


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors(options =>
                   options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            //app.UseMvc();
            app.UseRouting();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;

            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
