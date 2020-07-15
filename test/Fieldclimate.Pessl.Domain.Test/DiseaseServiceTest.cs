using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class DiseaseServiceTest : FieldClimatePesselTestBase
    {
        public DiseaseServiceTest()
        {
            
        }
        
        [Theory]
        [InlineData(DataGroup.daily, 2, TimePeriod.days)]
        [InlineData(DataGroup.hourly, 2, TimePeriod.days)]
        [InlineData(DataGroup.monthly, 2, TimePeriod.days)]
        [InlineData(DataGroup.raw, 2, TimePeriod.days)]
        [InlineData(DataGroup.daily, 2, TimePeriod.weeks)]
        [InlineData(DataGroup.hourly, 6, TimePeriod.hour)]
        [InlineData(DataGroup.monthly, 1, TimePeriod.months)]
        [InlineData(DataGroup.raw, 1, TimePeriod.months)]
        public async Task GetLast_deve_retornar_valor(DataGroup dataGroup, int numberOfEvents, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var diseaseService = scope.ServiceProvider.GetService<IDiseaseService>();
            
            var diseases = new[]
            {
                "SugarBeet/BeetCast",
                "SugarBeet/Cercopri"
            };

            var values = await diseaseService.GetLast(StationId, dataGroup, numberOfEvents, period, diseases);

            Assert.NotNull(values);
        }
    }
}