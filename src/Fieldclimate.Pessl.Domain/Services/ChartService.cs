using System;
using System.Collections.Generic;
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

        public async Task<dynamic> GetLastChart(string stationId, ChartType chartType, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"chart/{chartType.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return await GetAsync<dynamic>(requestUri);
        }

        public Task<IEnumerable<string>> GetForecastImageChart(string stationId, ForecastOptionImage optionData)
        {
            var requestUri = $"chart/image/{stationId}";

            var body = new
            {
                name = optionData.GetDescription()
            };

            return PostAsync<IEnumerable<string>>(requestUri, body);
        }
    }
}