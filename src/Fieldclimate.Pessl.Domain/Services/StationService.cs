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
    public class StationService : ServiceBase, IStationService
    {
        public StationService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        public Task<IEnumerable<Station>> GetAll()
        {
            const string requestUri = "/user/stations";
            return GetAsync<IEnumerable<Station>>(requestUri);
        }

        public Task<StationDetail> Get(string stationId)
        {
            var requestUri = $"/station/{stationId}";
            return GetAsync<StationDetail>(requestUri);
        }

        public async Task<StationData> GetData(string stationId, DataGroup groupBy, DateTimeOffset? from, DateTimeOffset? to)
        {
            var stationDetail = await Get(stationId);
            var configTimezoneOffsetInMinute = stationDetail.config.timezone_offset;
            var timeSpan = new TimeSpan(0, configTimezoneOffsetInMinute, 0);

            var minDate = from ?? stationDetail.dates.min_date;
            var maxDate = to ?? stationDetail.dates.max_date;

            var dbMinDate = minDate.ToOffset(timeSpan).ToUnixTimeSeconds();
            var dbMaxDate = maxDate.ToOffset(timeSpan).ToUnixTimeSeconds();

            var requestUri = $"/data/{stationId}/{groupBy}/from/{dbMinDate}/to/{dbMaxDate}";

            return await GetAsync<StationData>(requestUri);
        }

        public Task<StationData> GetLastData(string stationId, DataGroup groupBy)
        {
            var requestUri = $"/data/{stationId}/{groupBy}/last/1";

            return GetAsync<StationData>(requestUri);
        }

        public Task<IEnumerable<Sensor>> GetSensors(string stationId)
        {
            var requestUri = $"/station/{stationId}/sensors";
            return GetAsync<IEnumerable<Sensor>>(requestUri);
        }

        public Task<NodeRoot> GetNodes(string stationId)
        {
            var requestUri = $"/station/{stationId}/nodes";
            return GetAsync<NodeRoot>(requestUri);
        }

        public Task<dynamic> GetSerials(string stationId)
        {
            var requestUri = $"/station/{stationId}/serials";
            return GetAsync<dynamic>(requestUri);
        }

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

        public Task<IEnumerable<Event>> GetLastEvents(string stationId, int amount)
        {
            var requestUri = $"/station/{stationId}/events/last/{amount}/desc";
            return GetAsync<IEnumerable<Event>>(requestUri);
        }
    }
}