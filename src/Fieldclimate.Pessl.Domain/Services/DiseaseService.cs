using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    public class DiseaseService : ServiceBase, IDiseaseService
    {
        public DiseaseService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        public Task<StationDisease> GetLast(string stationId, DataGroup dataGroup, int numberOfEvents, TimePeriod timePeriod, IEnumerable<string> diseases)
        {
            var time = $"{numberOfEvents}{timePeriod.GetDescription()}";
            
            var requestUri = $"/data/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            var body = new
            {
                diseases = diseases
            };

            return PostAsync<StationDisease>(requestUri, body);
        }
    }
}