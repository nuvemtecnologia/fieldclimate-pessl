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
    /// <summary>
    /// 
    /// </summary>
    public class ChartService : ServiceBase, IChartService
    {
        /// <inheritdoc />
        public ChartService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        /// <inheritdoc />
        public Task<IEnumerable<HighChart>> GetLastHighChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"chart/{ChartType.Highchart.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return GetAsync<IEnumerable<HighChart>>(requestUri);
        }

        /// <inheritdoc />
        public Task<IEnumerable<string>> GetLastImagesChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"chart/{ChartType.Images.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return GetAsync<IEnumerable<string>>(requestUri);
        }

        /// <inheritdoc />
        public Task<IEnumerable<string>> GetLastImageChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"chart/{ChartType.Image.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            return GetAsync<IEnumerable<string>>(requestUri);
        }
        
        /// <inheritdoc />
        public Task<dynamic> GetHighChart(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to)
        {
            var requestUri = $"/chart/{ChartType.Highchart.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/from/{from.ToUnixTimeSeconds()}/to/{to.ToUnixTimeSeconds()}";
            return GetAsync<dynamic>(requestUri);
        }

        public Task<dynamic> GetImagesChart(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to)
        {
            var requestUri = $"/chart/{ChartType.Images.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/from/{from.ToUnixTimeSeconds()}/to/{to.ToUnixTimeSeconds()}";
            return GetAsync<dynamic>(requestUri);
        }

        public Task<dynamic> GeImageChart(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to)
        {
            var requestUri = $"/chart/{ChartType.Image.GetDescription()}/{stationId}/{dataGroup.GetDescription()}/from/{from.ToUnixTimeSeconds()}/to/{to.ToUnixTimeSeconds()}";
            return GetAsync<dynamic>(requestUri);
        }
    }
}