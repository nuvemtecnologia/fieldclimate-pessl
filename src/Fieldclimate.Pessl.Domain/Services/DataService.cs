using System;
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
    public class DataService : ServiceBase, IDataService
    {
        /// <inheritdoc />
        public DataService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        /// <inheritdoc />
        public async Task<StationData> GetData(string stationId, DataGroup groupBy, DateTimeOffset from, DateTimeOffset to)
        {
            var dbMinDate = from.ToUnixTimeSeconds();
            var dbMaxDate = to.ToUnixTimeSeconds();

            var requestUri = $"/data/{stationId}/{groupBy}/from/{dbMinDate}/to/{dbMaxDate}";

            return await GetAsync<StationData>(requestUri);
        }

        /// <inheritdoc />
        public Task<DateStation> Get(string stationId)
        {
            var requestUri = $"/data/{stationId}";
            return GetAsync<DateStation>(requestUri);
        }

        /// <inheritdoc />
        public Task<StationData> GetLastData(string stationId, DataGroup groupBy, int numberOfPeriod, TimePeriod period)
        {
            var time = $"{numberOfPeriod}{period.GetDescription()}";
            var requestUri = $"/data/{stationId}/{groupBy}/last/{time}";

            return GetAsync<StationData>(requestUri);
        }
    }
}