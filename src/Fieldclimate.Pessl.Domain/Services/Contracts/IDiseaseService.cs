using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;

namespace Fieldclimate.Pessl.Domain.Services.Contratos
{
    public interface IDiseaseService
    {
        Task<dynamic> GetLast(string stationId, DataGroup dataGroup, string time, IEnumerable<string> diseases);
    }
}