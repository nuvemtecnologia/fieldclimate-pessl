using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace Fieldclimate.Pessl.Domain.Services.Contratos
{
    public interface IStationService
    {
        Task<IEnumerable<Station>> GetAll();
        Task<StationDetail> GetDetail(string stationId);
        Task<StationData> GetData(string stationId, DataGroup groupBy, DateTimeOffset? from, DateTimeOffset? to);
        Task<StationData> GetLastData(string stationId, DataGroup groupBy);
        Task<IEnumerable<Sensor>> GetSensors(string stationId);
        Task<NodeRoot> GetNodes(string stationId);
        Task<dynamic> GetSerials(string stationId);
        Task<dynamic> GetOtherStationsByProximity(string stationId, string radius);
        Task<IEnumerable<Event>> GetLastEvents(string stationId, int amount);
    }
}