using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Services;
using Fieldclimate.Pessl.Domain.Services.Contratos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fieldclimate.Pessl.Domain.ExtensionsMethods
{
    public static class ServiceCollectionExtensionsMethods
    {
        public static IServiceCollection AddPessl(this IServiceCollection services, IConfiguration configuration)
        {
            var pesslConfiguration = GetPesslConfiguration(configuration);
            services.AddTransient<IPesslHttpClientFactory>(opt => new PesslHttpClientFactory(pesslConfiguration));

            services.AddTransient<IStationService, StationService>();
            services.AddTransient<ISystemService, SystemService>();
            services.AddTransient<IForecastService, ForecastService>();
            services.AddTransient<IDiseaseService, DiseaseService>();
            services.AddTransient<IChartService, ChartService>();

            return services;
        }

        private static PesslConfiguration GetPesslConfiguration(IConfiguration configuration)
        {
            return new PesslConfiguration
            {
                BaseAddress = configuration["Pessl:BaseAddress"],
                PrivateKey = configuration["Pessl:PrivateKey"],
                PublicKey = configuration["Pessl:PublicKey"]
            };
        }
    }
}