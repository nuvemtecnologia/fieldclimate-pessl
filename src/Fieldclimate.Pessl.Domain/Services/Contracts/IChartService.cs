using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Model.HighChart;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    public interface IChartService
    {
        Task<IEnumerable<string>> GetForecastImageChart(string stationId, ForecastOptionImage optionData);
        Task<IEnumerable<HighChart>> GetLastHighChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period);
        Task<IEnumerable<string>> GetLastImagesChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period);
        Task<IEnumerable<string>> GetLastImageChart(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period);
    }
}