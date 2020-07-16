using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Fieldclimate.Pessl.Domain.Test.Base;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class StationServiceTest : FieldClimatePesselTestBase
    {
        [Theory]
        [MemberData(nameof(GetAllStationIdInfoMemberData))]
        public async Task Get_deve_possuir_valor(string stationId)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.Get(stationId);
            Assert.NotNull(values);
        }

        [Theory]
        [MemberData(nameof(GetAllStationIdInfoMemberData))]
        public async Task GetSensors_deve_possuir_valor(string stationId)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();
            var values = await stationService.GetSensors(stationId);

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Theory]
        [MemberData(nameof(GetAllStationIdInfoMemberData))]
        public async Task GetNodes_deve_possuir_valor(string stationId)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();
            var values = await stationService.GetNodes(stationId);
            Assert.NotNull(values);
        }

        [Theory]
        [MemberData(nameof(GetAllStationIdInfoMemberData))]
        public async Task GetSerials_deve_possui_valor(string stationId)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();
            var values = await stationService.GetSerials(stationId);

            Assert.NotNull(values);
        }

        [Theory]
        [MemberData(nameof(GetOtherStationsByProximityMemberData))]
        public async Task GetOtherStationsByProximity_deve_possuir_valor(string stationId, int distance, RadiusUnity radiusUnity)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();
            var values = await stationService.GetOtherStationsByProximity(stationId, distance, radiusUnity);

            Assert.NotNull(values);
        }

        [Theory]
        [MemberData(nameof(GetLastEventsMemberData))]
        public async Task GetLastEvents_deve_possuir_valor(string stationId, int amount)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetLastEvents(stationId, amount);
            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        public static IEnumerable<object[]> GetOtherStationsByProximityMemberData()
        {
            var radiusUnities = EnumExtensions.GetValidOptions<RadiusUnity>();

            return (from stationId in AllStationsId
                from radiusUnity in radiusUnities
                select new object[]
                {
                    stationId,
                    10,
                    radiusUnity,
                }).ToList();
        }

        public static IEnumerable<object[]> GetLastEventsMemberData()
        {
            var amounts = new[] {10, 100};

            return (from stationId in AllStationsId
                from amount in amounts
                select new object[]
                {
                    stationId,
                    amount
                }).ToList();
        }
    }
}