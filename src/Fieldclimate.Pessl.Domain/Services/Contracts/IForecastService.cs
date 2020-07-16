using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#forecast
    /// ROUTES - FORECAST
    /// For retrieving forecast services for your device, you need specific licenses. Contact license@metos.at if you are interested.
    /// Every call regarding forecast, forecast fieldwork services, forecast animal services and forecast disease models is a POST HTTP call. The response is an hourly forecast by default.
    /// </summary>
    public interface IForecastService
    {
        /// <summary>
        /// POST /forecast/{{STATION-ID}}/{{DATA-GROUP}}
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="dataGroup"></param>
        /// <param name="nextDays"></param>
        /// <returns>Forecast data package or image</returns>
        Task<ForecastGeneral> Get(string stationId, DataGroup dataGroup, ForecastNextDays nextDays);

        /// <summary>
        /// POST /chart/image/{{STATION-ID}}
        /// Retrieve forecast image
        /// For retrieving forecast services for your device, you need specific licenses. Contact license@metos.at if you are interested.
        /// Every call regarding forecast images is a POST HTTP call. The response includes a link to the image for download.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="optionData"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> GetForecastImageChart(string stationId, ForecastOptionImage optionData);
    }
}