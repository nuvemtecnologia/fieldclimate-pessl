using System.Threading.Tasks;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class UserServiceTest : FieldClimatePesselTestBase
    {
        [Fact]
        public async Task Ao_buscar_stations_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IUserService>();

            var values = await stationService.GetStations();
            
            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }
    }
}