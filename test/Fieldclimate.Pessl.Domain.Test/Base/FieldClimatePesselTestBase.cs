using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Factories;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Fieldclimate.Pessl.Domain.Test.Base
{
    public class FieldClimatePesselTestBase
    {
        private static ServiceProvider _provider;
        private static IEnumerable<string> _stationsId;

        protected static ServiceProvider Provider => _provider ??= CreateServiceProvider();
        protected static IEnumerable<string> AllStationsId => _stationsId ??= GetAllStationsId().GetAwaiter().GetResult();
        protected static IEnumerable<string> CameraStationsId => new List<string>();

        protected static readonly string[] DefaultDiseases =
        {
            "SugarBeet/BeetCast",
            "SugarBeet/Cercopri"
        };

        private static ServiceProvider CreateServiceProvider()
        {
            var pesslPublicKey = Environment.GetEnvironmentVariable("PESSL_PUBLIC_KEY");
            var pesslPrivateKey = Environment.GetEnvironmentVariable("PESSL_PRIVATE_KEY");

            return new ServiceCollection()
                .AddFieldClimatePessl(new PesslConfiguration(pesslPublicKey, pesslPrivateKey))
                .BuildServiceProvider();
        }

        public static IEnumerable<object[]> GetAllStationIdInfoMemberData()
        {
            return (from stationId in AllStationsId
                select new object[]
                {
                    stationId,
                }).ToList();
        }

        private static async Task<IEnumerable<string>> GetAllStationsId()
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