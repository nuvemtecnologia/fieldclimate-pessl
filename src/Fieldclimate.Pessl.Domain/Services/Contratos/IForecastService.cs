using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace Fieldclimate.Pessl.Domain.Services.Contratos
{
    public interface IForecastService
    {
        Task<ForecastGeneral> Get(string stationId, DataGroup dataGroup, ForecastNextDays days);
    }
}