using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Model.HighChart;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    public class ChartService : ServiceBase, IChartService
    {
        public ChartService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        public Task<IEnumerable<HighChart>> GetLastHighChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"chart/{ChartType.highchart.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return GetAsync<IEnumerable<HighChart>>(requestUri);
        }

        public Task<IEnumerable<string>> GetLastImagesChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"chart/{ChartType.images.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return GetAsync<IEnumerable<string>>(requestUri);
        }

        public Task<IEnumerable<string>> GetLastImageChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"chart/{ChartType.image.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return GetAsync<IEnumerable<string>>(requestUri);
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