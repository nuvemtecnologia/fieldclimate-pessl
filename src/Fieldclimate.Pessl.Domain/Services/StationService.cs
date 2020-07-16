using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Newtonsoft.Json.Linq;

namespace Fieldclimate.Pessl.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class StationService : ServiceBase, IStationService
    {
        /// <inheritdoc />
        public StationService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        /// <inheritdoc />
        public Task<StationDetail> Get(string stationId)
        {
            var requestUri = $"/station/{stationId}";
            return GetAsync<StationDetail>(requestUri);
        }

        /// <inheritdoc />
        public Task<IEnumerable<Sensor>> GetSensors(string stationId)
        {
            var requestUri = $"/station/{stationId}/sensors";
            return GetAsync<IEnumerable<Sensor>>(requestUri);
        }

        /// <inheritdoc />
        public Task<NodeRoot> GetNodes(string stationId)
        {
            var requestUri = $"/station/{stationId}/nodes";
            return GetAsync<NodeRoot>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetSerials(string stationId)
        {
            var requestUri = $"/station/{stationId}/serials";
            return GetAsync<dynamic>(requestUri);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<StationProximity>> GetOtherStationsByProximity(string stationId, int distance, RadiusUnity radiusUnity)
        {
            var radius = $"{distance}{radiusUnity.GetDescription()}";
            var requestUri = $"/station/{stationId}/proximity/{radius}";

            var values = await GetAsync<dynamic>(requestUri);

            var result = new List<StationProximity>();

            if (!(values is JObject jObject)) return result;

            foreach (var (key, value) in jObject)
            {
                result.Add(
                    new StationProximity()
                    {
                        StationId = key,
                        Coordinate = value.ToObject<Coordinate>()
                    });
            }

            return result;
        }

        /// <inheritdoc />
        public Task<IEnumerable<Event>> GetLastEvents(string stationId, int amount, Sort sort = Sort.Asc)
        {
            var requestUri = $"/station/{stationId}/events/last/{amount}/{sort.GetDescription()}";
            return GetAsync<IEnumerable<Event>>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetEvents(string stationId, DateTimeOffset from, DateTimeOffset to, Sort sort = Sort.Asc)
        {
            var requestUri = $"/station/{stationId}/events/from/{from.ToUnixTimeSeconds()}/to/{to.ToUnixTimeSeconds()}/{sort.GetDescription()}";
            return GetAsync<dynamic>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetTransmissionHistory(string stationId, TransmissionHistoryFilter filter, int amount, Sort sort = Sort.Asc)
        {
            var requestUri = $"/station/{stationId}/history/{filter.GetDescription()}/last/{amount}/{sort.GetDescription()}";
            return GetAsync<dynamic>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetTransmissionHistory(string stationId, TransmissionHistoryFilter filter, DateTimeOffset from, DateTimeOffset to, Sort sort = Sort.Asc)
        {
            var requestUri = $"/station/{stationId}/history/{filter.GetDescription()}/from/{from.ToUnixTimeSeconds()}/to/{to.ToUnixTimeSeconds()}/{sort.GetDescription()}";
            return GetAsync<dynamic>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetLicenses(string stationId)
        {
            var requestUri = $"/station/{stationId}/licenses";
            return GetAsync<dynamic>(requestUri);
        }
    }
}