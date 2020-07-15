using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    public interface IDiseaseService
    {
        Task<StationDisease> GetLast(string stationId, DataGroup dataGroup, string time, IEnumerable<string> diseases);
    }
}