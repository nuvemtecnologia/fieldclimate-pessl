using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class ForecastServiceTest : FieldClimatePesselTestBase
    {
        [Theory]
        [InlineData(DataGroup.daily, ForecastNextDays.general3)]
        [InlineData(DataGroup.hourly, ForecastNextDays.general3)]
        [InlineData(DataGroup.monthly, ForecastNextDays.general3)]
        [InlineData(DataGroup.raw, ForecastNextDays.general3)]
        [InlineData(DataGroup.daily, ForecastNextDays.general7)]
        [InlineData(DataGroup.hourly, ForecastNextDays.general7)]
        [InlineData(DataGroup.monthly, ForecastNextDays.general7)]
        [InlineData(DataGroup.raw, ForecastNextDays.general7)]
        public async Task Ao_buscar_previsao_retorno_deve_possui_valor(DataGroup dataGroup, ForecastNextDays nextDays)
        {
            using var scope = Provider.CreateScope();
            var forecastService = scope.ServiceProvider.GetService<IForecastService>();

            foreach (var stationId in StationsId)
            {
                var values = await forecastService.Get(stationId, dataGroup, nextDays);
                Assert.NotNull(values);
            }
        }
    }
}