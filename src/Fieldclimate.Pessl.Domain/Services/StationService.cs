using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;

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

        public Task<Station> Get(string stationId)
        {
            var requestUri = $"/station/{stationId}";
            return GetAsync<Station>(requestUri);
        }

        public async Task<StationData> GetData(string stationId, DataGroup groupBy, DateTimeOffset? from, DateTimeOffset? to)
        {
            var stationDetail = await Get(stationId);
            var configTimezoneOffsetInMinute = stationDetail.config.timezone_offset;
            var timeSpan = new TimeSpan(0, configTimezoneOffsetInMinute, 0);

            var minDate = from ?? DateTimeOffset.Parse(stationDetail.dates.min_date);
            var maxDate = to ?? DateTimeOffset.Parse(stationDetail.dates.max_date);

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

        public Task<dynamic> GetOtherStationsByProximity(string stationId, string radius)
        {
            var requestUri = $"/station/{stationId}/proximity/{radius}";
            return GetAsync<dynamic>(requestUri);
        }

        public Task<IEnumerable<Event>> GetLastEvents(string stationId, int amount)
        {
            var requestUri = $"/station/{stationId}/events/last/{amount}/desc";
            return GetAsync<IEnumerable<Event>>(requestUri);
        }
    }
}