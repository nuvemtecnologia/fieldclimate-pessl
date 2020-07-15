using System;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    public class ForecastService : ServiceBase, IForecastService
    {
        public ForecastService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        public Task<ForecastGeneral> Get(string stationId, DataGroup dataGroup, ForecastNextDays days)
        {
            var requestUri = $"/forecast/{stationId}/{dataGroup.GetDescription()}";

            var body = new
            {
                name = days.GetDescription()
            };

            return PostAsync<ForecastGeneral>(requestUri, body);
        }
    }
}