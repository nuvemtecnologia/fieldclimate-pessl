using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Fieldclimate.Pessl.Domain.Test.Base;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class ChartServiceTest : FieldClimatePesselTestBase
    {
        public static IEnumerable<object[]> GetMemberData()
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
        [MemberData(nameof(GetMemberData))]
        public async Task GetLastHighchart_deve_retornar_valor(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetLastHighChart(stationId, dataGroup, numberOfPeriod, period);

            Assert.NotNull(lastChart);
           
        }


        [Theory]
        [MemberData(nameof(GetMemberData))]
        public async Task GetLastImageChart_deve_retornar_valor(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetLastImageChart(stationId, dataGroup, numberOfPeriod, period);

            Assert.NotNull(lastChart);
        }

        [Theory]
        [MemberData(nameof(GetMemberData))]
        public async Task GetLastImagesChart_deve_retornar_valor(string stationId, DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();
            var lastChart = await chartService.GetLastImagesChart(stationId, dataGroup, numberOfPeriod, period);

            Assert.NotNull(lastChart);
           
        }
    }
}