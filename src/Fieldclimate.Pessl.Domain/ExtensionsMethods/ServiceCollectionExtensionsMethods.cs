using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Services;
using FieldClimate.Pessl.Domain.Services.Contracts;

// ReSharper disable once CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceCollectionExtensionsMethods
    {
        /// <summary>
        /// AddTransient of all necessary dependencies
        /// </summary>
        /// <param name="services"></param>
        /// <param name="pesslConfiguration"></param>
        /// <returns></returns>
        public static IServiceCollection AddFieldClimatePessl(this IServiceCollection services, PesslConfiguration pesslConfiguration)
        {
            services.AddTransient<IPesslHttpClientFactory>(opt => new PesslHttpClientFactory(pesslConfiguration));

            services.AddTransient<IStationService, StationService>();
            services.AddTransient<ISystemService, SystemService>();
            services.AddTransient<IForecastService, ForecastService>();
            services.AddTransient<IDiseaseService, DiseaseService>();
            services.AddTransient<IChartService, ChartService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDataService, DataService>();

            return services;
        }
    }
}