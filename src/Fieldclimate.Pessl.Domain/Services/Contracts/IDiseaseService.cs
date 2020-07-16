using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#diseases
    /// ROUTES - DISEASE
    /// </summary>
    public interface IDiseaseService
    {
        /// <summary>
        /// POST /data/{{STATION-ID}}/{{DATA-GROUP}}/last/{{TIME-PERIOD}}
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="dataGroup">Target resolution for data aggregation</param>
        /// <param name="numberOfEvents"></param>
        /// <param name="timePeriod"></param>
        /// <param name="diseasesFilter"></param>
        /// <returns>Retrieve last specified disease model(s)</returns>
        Task<StationDisease> GetLast(string stationId, DataGroup dataGroup, int numberOfEvents, TimePeriod timePeriod, IEnumerable<string> diseasesFilter = null);

        /// <summary>
        /// POST /data/{{STATION-ID}}/{{DATA-GROUP}}/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="dataGroup">Target resolution for data aggregation</param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="diseasesFilter"></param>
        /// <returns>Retrieve specified disease model(s) for period</returns>
        Task<StationDisease> Get(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to, IEnumerable<string> diseasesFilter = null);
    }
}