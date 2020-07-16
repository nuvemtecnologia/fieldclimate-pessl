using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using FieldClimate.Pessl.Domain.Model.HighChart;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#chart
    /// ROUTES - CHART
    /// Retrieving charts or images of your device, forecast and disease model data with help of VIEW (Please refer to VIEW documentation under INFO section).
    /// You are limited to retrieve MAX 10.000 data points.
    /// </summary>
    public interface IChartService
    {
        /// <summary>
        /// GET /chart/highchart/{{STATION-ID}}/{{DATA-GROUP}}/last/{{TIME-PERIOD}}
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="dataGroup"></param>
        /// <param name="numberOfPeriod"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        Task<IEnumerable<HighChart>> GetLastHighChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period);
        
        /// <summary>
        /// GET /chart/images/{{STATION-ID}}/{{DATA-GROUP}}/last/{{TIME-PERIOD}}
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="dataGroup"></param>
        /// <param name="numberOfPeriod"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetLastImagesChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period);
        
        /// <summary>
        /// GET /chart/image/{{STATION-ID}}/{{DATA-GROUP}}/last/{{TIME-PERIOD}}
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="dataGroup"></param>
        /// <param name="numberOfPeriod"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetLastImageChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period);
        
        /// <summary>
        /// GET /chart/highchart/{{STATION-ID}}/{{DATA-GROUP}}/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="dataGroup"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        Task<dynamic> GetHighChart(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to);
        
        /// <summary>
        /// GET /chart/images}/{{STATION-ID}}/{{DATA-GROUP}}/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="dataGroup"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        Task<dynamic> GetImagesChart(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to);
        
        /// <summary>
        /// GET /chart/image/{{STATION-ID}}/{{DATA-GROUP}}/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}
        /// </summary>
        /// <param name="stationId"></param>
        /// <param name="dataGroup"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        Task<dynamic> GeImageChart(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to);
    }
}