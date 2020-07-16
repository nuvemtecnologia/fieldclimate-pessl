using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Fieldclimate.Pessl.Domain.Test.Base;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class StationServiceTest : FieldClimatePesselTestBase
    {
        private static readonly DateTimeOffset From = new DateTime(2020, 1, 1);
        private static readonly DateTimeOffset To = new DateTime(2020, 1, 30);

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
            
        }

        [Theory]
        [MemberData(nameof(GetEventsMemberData))]
        public async Task GetEvents_deve_possuir_valor(string stationId, DateTimeOffset from, DateTimeOffset to, Sort sort)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetEvents(stationId, from, to, sort);
            Assert.NotNull(values);
            
        }
        
        [Theory]
        [MemberData(nameof(GetTransmissionHistoryMemberData))]
        public async Task GetTransmissionHistory_deve_possuir_valor(string stationId, TransmissionHistoryFilter filter, int amount, Sort sort)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetTransmissionHistory(stationId, filter, amount, sort);
            Assert.NotNull(values);
            
        }
        
        [Theory]
        [MemberData(nameof(GetTransmissionHistory_por_periodoMemberData))]
        public async Task GetTransmissionHistory_por_periodo_deve_possuir_valor(string stationId, TransmissionHistoryFilter filter, DateTimeOffset from, DateTimeOffset to, Sort sort)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetTransmissionHistory(stationId, filter, from, to, sort);
            Assert.NotNull(values);
            
        }

        [Theory]
        [MemberData(nameof(GetAllStationIdInfoMemberData))]
        public async Task GetLicenses_deve_possuir_valor(string stationId)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetLicenses(stationId);
            Assert.NotNull(values);
            
        }

        public static IEnumerable<object[]> GetEventsMemberData()
        {
            var sorts = EnumExtensions.GetValidOptions<Sort>();

            return (from stationId in AllStationsId
                from sort in sorts
                select new object[]
                {
                    stationId,
                    From,
                    To,
                    sort,
                }).ToList();
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
        
        public static IEnumerable<object[]> GetTransmissionHistoryMemberData()
        {
            var transmissionHistoryFilters = EnumExtensions.GetValidOptions<TransmissionHistoryFilter>();
            var sorts = EnumExtensions.GetValidOptions<Sort>();

            return (from stationId in AllStationsId
                from filter in transmissionHistoryFilters
                from sort in sorts
                select new object[]
                {
                    stationId,
                    filter,
                    10,
                    sort,
                }).ToList();
        }
        
        public static IEnumerable<object[]> GetTransmissionHistory_por_periodoMemberData()
        {
            var transmissionHistoryFilters = EnumExtensions.GetValidOptions<TransmissionHistoryFilter>();
            var sorts = EnumExtensions.GetValidOptions<Sort>();

            return (from stationId in AllStationsId
                from filter in transmissionHistoryFilters
                from sort in sorts
                select new object[]
                {
                    stationId,
                    filter,
                    From,
                    To,
                    sort,
                }).ToList();
        }
    }
}