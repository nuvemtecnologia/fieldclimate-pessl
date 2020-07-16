using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Factories;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class FieldClimatePesselTestBase
    {
        private static IEnumerable<string> _stationsId;

        protected ServiceProvider Provider { get; }

        protected IEnumerable<string> StationsId => _stationsId ??= GetAllStationsId().GetAwaiter().GetResult();


        protected FieldClimatePesselTestBase()
        {
            var publicKey = Environment.GetEnvironmentVariable("PESSL_PUBLIC_KEY");
            var privateKey = Environment.GetEnvironmentVariable("PESSL_PRIVATE_KEY");

            Provider = new ServiceCollection()
                .AddFieldClimatePessl(new PesslConfiguration(publicKey, privateKey))
                .BuildServiceProvider();
        }

        private async Task<IEnumerable<string>> GetAllStationsId()
        {
            return new[]
            {
                "00002AD4"
            };

            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IUserService>();

            var values = await stationService.GetStations();

            return values.Select(x => x.name.original);
        }
    }
}