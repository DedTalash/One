using System;
using Hangfire;
using Hangfire.PostgreSql;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using One.Core;
using One.Core.Interfaces;
using One.DB;
using One.Infrastructure;

namespace One.Updater
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
            var connectionString = Configuration.GetSection("DbConnection").Get<string>();
            var apiKey = Configuration.GetSection("ApiKey").Get<string>();
            services.AddHangfire(x => x.UsePostgreSqlStorage(connectionString));
            services.AddHangfireServer();
            services.AddHttpClient<IWeatherMapClient>(cl => new WeatherMapClientImpl(apiKey, cl));
            services.AddTransient<IWeatherRepo>(ctx => new WeatherRepo(connectionString));
            services.AddTransient<WeatherService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
            
            app.UseHangfireDashboard();
            
            RecurringJob.AddOrUpdate<WeatherService>(
                "weather-update",
                s => s.UpdateBD(),
                Cron.Daily);
        }
    }
}