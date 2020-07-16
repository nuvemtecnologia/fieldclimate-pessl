using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ForecastService : ServiceBase, IForecastService
    {
        /// <inheritdoc />
        public ForecastService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        /// <inheritdoc />
        public Task<ForecastGeneral> Get(string stationId, DataGroup dataGroup, ForecastNextDays nextDays)
        {
            var requestUri = $"/forecast/{stationId}/{dataGroup.GetDescription()}";

            var body = new
            {
                name = nextDays.GetDescription()
            };

            return PostAsync<ForecastGeneral>(requestUri, body);
        }

        /// <inheritdoc />
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