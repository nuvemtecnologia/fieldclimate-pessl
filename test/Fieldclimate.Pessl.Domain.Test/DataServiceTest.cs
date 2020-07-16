using System;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class DataServiceTest : FieldClimatePesselTestBase
    {
        [Theory]
        [InlineData(DataGroup.daily)]
        [InlineData(DataGroup.hourly)]
        [InlineData(DataGroup.monthly)]
        [InlineData(DataGroup.raw)]
        public async Task Ao_buscar_dado_da_estacao_por_periodo_retorno_deve_possuir_valor(DataGroup dataGroup)
        {
            var from = new DateTime(2020, 1, 1);
            var to = new DateTime(2020, 2, 1);

            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IDataService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.GetData(stationId, dataGroup, from, to);
                Assert.NotNull(values);
            }
        }

        [Theory]
        [InlineData(DataGroup.daily, 5, TimePeriod.days)]
        [InlineData(DataGroup.hourly, 5, TimePeriod.days)]
        [InlineData(DataGroup.monthly, 5, TimePeriod.days)]
        [InlineData(DataGroup.raw, 5, TimePeriod.days)]
        [InlineData(DataGroup.daily, 48, TimePeriod.hour)]
        [InlineData(DataGroup.hourly, 48, TimePeriod.hour)]
        [InlineData(DataGroup.monthly, 48, TimePeriod.hour)]
        [InlineData(DataGroup.raw, 48, TimePeriod.hour)]
        [InlineData(DataGroup.daily, 2, TimePeriod.months)]
        [InlineData(DataGroup.hourly, 2, TimePeriod.months)]
        [InlineData(DataGroup.monthly, 2, TimePeriod.months)]
        [InlineData(DataGroup.raw, 2, TimePeriod.months)]
        [InlineData(DataGroup.daily, 4, TimePeriod.weeks)]
        [InlineData(DataGroup.hourly, 4, TimePeriod.weeks)]
        [InlineData(DataGroup.monthly, 4, TimePeriod.weeks)]
        [InlineData(DataGroup.raw, 4, TimePeriod.weeks)]
        public async Task GetLastData_deve_retorno_valor(DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IDataService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.GetLastData(stationId, dataGroup, numberOfPeriod, period);
                Assert.NotNull(values);
            }
        }
    }
}