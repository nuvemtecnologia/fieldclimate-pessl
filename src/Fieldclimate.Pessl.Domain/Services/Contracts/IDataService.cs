using System;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#data
    /// ROUTES - DATA
    /// Retrieving your measured and calculated historic data.
    /// You are limited to retrieve MAX 10.000 data points.
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// GET	/data/{{STATION-ID}}
        /// Retrieve min and max date of device data availability. This request can be used to check if device has sent new data which you can retrieve, by just memorizing last max_date and compare it with current one.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <returns>Min and Max date of data availability</returns>
        Task<DateStation> Get(string stationId);

        /// <summary>
        /// GET	/data/{{STATION-ID}}/{{DATA-GROUP}}/last/{{TIME-PERIOD}}
        /// Retrieve last data that device sends. We recommend calling /data/{{STATION-ID}} first so you can see if there is any new data.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="groupBy"></param>
        /// <param name="numberOfPeriod"></param>
        /// <param name="period"></param>
        /// <returns>Last data</returns>
        Task<StationData> GetLastData(string stationId, DataGroup groupBy, int numberOfPeriod, TimePeriod period);

        /// <summary>
        /// GET /data/{{STATION-ID}}/{{DATA-GROUP}}/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}
        /// Retrieve data between specified time periods. We recommend calling /data/{{STATION-ID}} first so you can see if there is any new data. Times from and to need to be specified in unix timestamp.
        /// You are limited to retrieve MAX 10.000 data points.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="groupBy"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns>Data of specific time period</returns>
        Task<StationData> GetData(string stationId, DataGroup groupBy, DateTimeOffset from, DateTimeOffset to);
    }
}