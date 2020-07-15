using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAll();
        Task<StationDetail> Get(string stationId);
        Task<StationData> GetData(string stationId, DataGroup groupBy, DateTimeOffset? from, DateTimeOffset? to);
        Task<StationData> GetLastData(string stationId, DataGroup groupBy);
        Task<IEnumerable<Sensor>> GetSensors(string stationId);
        Task<NodeRoot> GetNodes(string stationId);
        Task<dynamic> GetSerials(string stationId);
        Task<IEnumerable<StationProximity>> GetOtherStationsByProximity(string stationId, int distance, RadiusUnity radiusUnity);
        Task<IEnumerable<Event>> GetLastEvents(string stationId, int amount);
    }
}