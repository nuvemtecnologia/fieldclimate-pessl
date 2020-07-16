using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#station
    /// ROUTES - STATION
    /// All the information that is related to your device.
    /// </summary>
    public interface IStationService
    {
        /// <summary>
        /// /station/{{STATION-ID}}
        /// Reading station information.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <returns>station information</returns>
        Task<StationDetail> Get(string stationId);

        /// <summary>
        /// /station/{{STATION-ID}}/sensors.
        /// Reading the list of all sensors that your device has/had.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <returns>list of sensors of a station</returns>
        Task<IEnumerable<Sensor>> GetSensors(string stationId);

        /// <summary>
        /// /station/{{STATION-ID}}/nodes
        /// Station nodes are wireless nodes connected to base station (STATION-ID). Here you can list custom names if any of a node has custom name.
        /// To get list of nodes we suggest using call /station/{{STATION-ID}}/sensors and each sensor has MAC address.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <returns>list of nodes (wireless devices) connected to a station</returns>
        Task<NodeRoot> GetNodes(string stationId);

        /// <summary>
        /// /station/{{STATION-ID}}/serials
        /// Sensor serials settings. If there are no settings we get no content response.
        /// To get list of all sensors serials we suggest using call /station/{{STATION-ID}}/sensors where each sensor has serial tag.
        /// Serial is normally used by drill and drop sensors where we get for one sensor 6 or more sensor outputs as drill and drop contains multiple sensors at specific depth. To identify this sensor as a whole we introduced serial.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <returns>List of serials (of a sensor) and their names</returns>
        Task<dynamic> GetSerials(string stationId);

        /// <summary>
        /// /station/{{STATION-ID}}/proximity/{{RADIUS}}
        /// Find stations in proximity of specified station
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="distance"></param>
        /// <param name="radiusUnity"></param>
        /// <returns>Stations in close proximity of specified station</returns>
        Task<IEnumerable<StationProximity>> GetOtherStationsByProximity(string stationId, int distance, RadiusUnity radiusUnity);

        /// <summary>
        /// /station/{{STATION-ID}}/events/last/{{AMOUNT}}
        /// Read last X amount of station events. Optionally you can also sort them ASC or DESC.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="amount"></param>
        /// <param name="sort"></param>
        /// <returns>Last station events</returns>
        Task<IEnumerable<Event>> GetLastEvents(string stationId, int amount, Sort sort = Sort.Asc);

        /// <summary>
        /// /station/{{STATION-ID}}/events/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}/{{SORT}}
        /// Read station events between time period you select. Optionally you can also sort them ASC or DESC.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sort"></param>
        /// <returns>Station events from to</returns>
        Task<dynamic> GetEvents(string stationId, DateTimeOffset from, DateTimeOffset to, Sort sort = Sort.Asc);

        /// <summary>
        /// GET /station/{{STATION-ID}}/history/{{FILTER}}/last/{{AMOUNT}}/{{SORT}}
        /// Read last X amount of station transmission history. Optionally you can also sort them ASC or DESC and filter.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="filter"></param>
        /// <param name="amount"></param>
        /// <param name="sort"></param>
        /// <returns>Last station communication history filter</returns>
        Task<dynamic> GetTransmissionHistory(string stationId, TransmissionHistoryFilter filter, int amount, Sort sort = Sort.Asc);

        /// <summary>
        /// GET /station/{{STATION-ID}}/history/{{FILTER}}/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}/{{SORT}}
        /// Read transmission history for specific time period. Optionally you can also sort them ASC or DESC and filter.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="filter"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        Task<dynamic> GetTransmissionHistory(string stationId, TransmissionHistoryFilter filter, DateTimeOffset from, DateTimeOffset to, Sort sort = Sort.Asc);

        /// <summary>
        /// /station/{{STATION-ID}}/licenses
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <returns>Station licenses for disease models or forecast</returns>
        Task<dynamic> GetLicenses(string stationId);
    }
}