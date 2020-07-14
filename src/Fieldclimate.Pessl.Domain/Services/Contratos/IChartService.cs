using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;

namespace Fieldclimate.Pessl.Domain.Services.Contratos
{
    public interface IChartService
    {
        Task<dynamic> GetForecastImageChart(string stationId, ForecastOptionImage optionData);
        Task<dynamic> GetLastChart(string stationId, ChartType chartType, DataGroup dataGroup, string time);
    }
}