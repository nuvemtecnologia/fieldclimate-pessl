using System;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    public class ChartService : ServiceBase, IChartService
    {
        public ChartService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        public Task<dynamic> GetLastChart(string stationId, ChartType chartType, DataGroup dataGroup, string time)
        {
            var requestUri = $"chart/{chartType.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return GetAsync<dynamic>(requestUri);
        }

        public Task<dynamic> GetForecastImageChart(string stationId, ForecastOptionImage optionData)
        {
            var requestUri = $"chart/image/{stationId}";

            var body = new
            {
                name = optionData.GetDescription()
            };

            return PostAsync<dynamic>(requestUri, body);
        }
    }
}