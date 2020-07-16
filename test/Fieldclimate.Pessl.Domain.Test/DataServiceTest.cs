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
    public class DataServiceTest : FieldClimatePesselTestBase
    {
        private static readonly DateTimeOffset From = new DateTime(2020, 1, 1);
        private static readonly DateTimeOffset To = new DateTime(2020, 1, 30);

        public static IEnumerable<object[]> GetDataPorPeriodoMemberData()
        {
            var dataGroups = EnumExtensions.GetValidOptions<DataGroup>();

            return (from stationId in AllStationsId
                from dataGroup in dataGroups
                select new object[]
                {
                    stationId,
                    dataGroup,
                    From,
                    To
                }).ToList();
        }

        public static IEnumerable<object[]> GetLastDataMemberData()
        {
            var dataGroups = EnumExtensions.GetValidOptions<DataGroup>();
            var timePeriods = EnumExtensions.GetValidOptions<TimePeriod>();

            return (from stationId in AllStationsId
                from dataGroup in dataGroups
                from timePeriod in timePeriods
                select new object[]
                {
                    stationId,
                    dataGroup,
                    2,
                    timePeriod
                }).ToList();
        }

        [Theory]
        [MemberData(nameof(GetDataPorPeriodoMemberData))]
        public async Task GetData_por_periodo_deve_retorno_valor(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IDataService>();

            var values = await stationService.GetData(stationId, dataGroup, from, to);
            Assert.NotNull(values);
        }

        [Theory]
        [MemberData(nameof(GetLastDataMemberData))]
        public async Task GetLastData_deve_retorno_valor(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IDataService>();

            var values = await stationService.GetLastData(stationId, dataGroup, numberOfPeriod, period);
            Assert.NotNull(values);
        }
    }
}