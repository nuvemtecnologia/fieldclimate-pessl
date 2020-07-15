using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    public interface IForecastService
    {
        Task<ForecastGeneral> Get(string stationId, DataGroup dataGroup, ForecastNextDays days);
    }
}