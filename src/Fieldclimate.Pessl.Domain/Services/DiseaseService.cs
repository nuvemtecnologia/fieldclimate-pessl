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
    public class DiseaseService : ServiceBase, IDiseaseService
    {
        /// <inheritdoc />
        public DiseaseService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        /// <inheritdoc />
        public Task<StationDisease> GetLast(string stationId, DataGroup dataGroup, int numberOfEvents, TimePeriod timePeriod, IEnumerable<string> diseasesFilter = null)
        {
            var time = $"{numberOfEvents}{timePeriod.GetDescription()}";

            var requestUri = $"/data/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            var body = new
            {
                diseases = diseasesFilter
            };

            return PostAsync<StationDisease>(requestUri, body);
        }

        /// <inheritdoc />
        public Task<StationDisease> Get(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to, IEnumerable<string> diseasesFilter = null)
        {
            var requestUri = $"/data/{stationId}/{dataGroup.GetDescription()}/from/{from.ToUnixTimeSeconds()}/to/{to.ToUnixTimeSeconds()}";

            var body = new
            {
                diseases = diseasesFilter
            };

            return PostAsync<StationDisease>(requestUri, body);
        }
    }
}