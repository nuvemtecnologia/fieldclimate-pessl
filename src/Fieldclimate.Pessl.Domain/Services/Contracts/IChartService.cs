using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    public interface IChartService
    {
        Task<IEnumerable<string>> GetForecastImageChart(string stationId, ForecastOptionImage optionData);
        Task<dynamic> GetLastChart(string stationId, ChartType chartType, DataGroup dataGroup, string time);
    }
}