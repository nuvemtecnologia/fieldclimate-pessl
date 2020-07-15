using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Services;
using FieldClimate.Pessl.Domain.Services.Contracts;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensionsMethods
    {
        public static IServiceCollection AddFieldClimatePessl(this IServiceCollection services, PesslConfiguration pesslConfiguration)
        {
            services.AddTransient<IPesslHttpClientFactory>(opt => new PesslHttpClientFactory(pesslConfiguration));

            services.AddTransient<IStationService, StationService>();
            services.AddTransient<ISystemService, SystemService>();
            services.AddTransient<IForecastService, ForecastService>();
            services.AddTransient<IDiseaseService, DiseaseService>();
            services.AddTransient<IChartService, ChartService>();

            return services;
        }
    }
}