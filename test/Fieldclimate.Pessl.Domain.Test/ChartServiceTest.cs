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
    public class ChartServiceTest : FieldClimatePesselTestBase
    {
        private static readonly DateTimeOffset From = new DateTime(2020, 1, 1);
        private static readonly DateTimeOffset To = new DateTime(2020, 1, 30);

        public static IEnumerable<object[]> GetLastMemberData()
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

        public static IEnumerable<object[]> GetByPeriodoMemberData()
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

        [Theory]
        [MemberData(nameof(GetLastMemberData))]
        public async Task GetLastHighchart_deve_retornar_valor(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetLastHighChart(stationId, dataGroup, numberOfPeriod, period);

            Assert.NotNull(lastChart);
        }

        [Theory]
        [MemberData(nameof(GetLastMemberData))]
        public async Task GetLastImageChart_deve_retornar_valor(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetLastImageChart(stationId, dataGroup, numberOfPeriod, period);

            Assert.NotNull(lastChart);
        }

        [Theory]
        [MemberData(nameof(GetLastMemberData))]
        public async Task GetLastImagesChart_deve_retornar_valor(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetLastImagesChart(stationId, dataGroup, numberOfPeriod, period);

            Assert.NotNull(lastChart);
        }


        [Theory]
        [MemberData(nameof(GetByPeriodoMemberData))]
        public async Task GetHighChart_deve_retornar_valor(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetHighChart(stationId, dataGroup, from, to);

            Assert.NotNull(lastChart);
        }

        [Theory]
        [MemberData(nameof(GetByPeriodoMemberData))]
        public async Task GetImagesChart_deve_retornar_valor(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetImagesChart(stationId, dataGroup, from, to);

            Assert.NotNull(lastChart);
        }

        [Theory]
        [MemberData(nameof(GetByPeriodoMemberData))]
        public async Task GetImageChart_deve_retornar_valor(string stationId, DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetImageChart(stationId, dataGroup, from, to);

            Assert.NotNull(lastChart);
        }
    }
}