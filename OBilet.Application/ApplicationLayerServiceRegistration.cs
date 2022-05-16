using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OBilet.Application.Features.Categories.Queries;
using OBilet.Application.Features.Services;
using OBilet.Application.Features.Services.Configurations;
using System;
using System.Net.Http.Headers;

namespace OBilet.Application
{
    public static class ApplicationLayerServiceRegistration
    {
        public static IServiceCollection AddApplicationLayerServices(this IServiceCollection services)
        {
            //services.Configure(options);

            services.AddMediatR(typeof(BusLocationQuery));            
            services.AddHttpClient(OBiletConfiguration.ServiceCollectorName, (sp, cfg) =>
            {
                var obiletSettings = sp.GetRequiredService<IOptions<OBiletConfiguration>>().Value;
                cfg.BaseAddress = new Uri(obiletSettings.BaseUri);
                cfg.DefaultRequestHeaders.Accept.Clear();
                cfg.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(obiletSettings.MediaType));
                cfg.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(obiletSettings.AuthType, obiletSettings.Token);
            });
            services.AddScoped<IObiletService, OBiletService>();
            return services;
        }
    }
}
