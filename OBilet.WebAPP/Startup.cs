using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using OBilet.WebAPP.Configurations;
using OBilet.WebAPP.Service;
using System;
using System.Net.Http.Headers;

namespace OBilet.WebAPP
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
            services.Configure<ApiConfiguration>(Configuration.GetSection(typeof(ApiConfiguration).Name));
            services.AddSingleton<IApiConfiguration>(sp => { return sp.GetRequiredService<IOptions<ApiConfiguration>>().Value; });
            
            services.AddHttpClient(ApiConfiguration.ServiceCollectorName, (sp, cfg) =>
            {
                var apiSettings = sp.GetRequiredService<IOptions<ApiConfiguration>>().Value;
                cfg.BaseAddress = new Uri(apiSettings.BaseUri);
                cfg.DefaultRequestHeaders.Accept.Clear();
                cfg.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(apiSettings.MediaType));
            });
            services.AddScoped<IApiService, ApiService>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
