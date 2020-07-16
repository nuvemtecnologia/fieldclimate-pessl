using System.Net;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Test.Base;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class CredentialTest : FieldClimatePesselTestBase
    {
        [Fact]
        public async Task Ao_realizar_request_credencial_deve_ser_valida()
        {
            using var scope = Provider.CreateScope();
            var pesslHttpClientFactory = scope.ServiceProvider.GetService<IPesslHttpClientFactory>();

            var httpClient = pesslHttpClientFactory.Create();
            var response = await httpClient.GetAsync("system/status");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}