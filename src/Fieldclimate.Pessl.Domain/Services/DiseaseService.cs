using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Services.Contratos;

namespace Fieldclimate.Pessl.Domain.Services
{
    public class DiseaseService : ServiceBase, IDiseaseService
    {
        public DiseaseService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        public Task<dynamic> GetLast(string stationId, DataGroup dataGroup, string time, IEnumerable<string> diseases)
        {
            var requestUri = $"/data/{stationId}/{dataGroup.GetDescription()}/last/{time}";

            var body = new
            {
                diseases = diseases
            };

            return PostAsync<dynamic, dynamic>(requestUri, body);
        }
    }
}