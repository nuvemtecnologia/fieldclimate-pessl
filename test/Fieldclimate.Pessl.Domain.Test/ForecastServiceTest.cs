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
    public class ForecastServiceTest : FieldClimatePesselTestBase
    {
        public static IEnumerable<object[]> GetMemberData()
        {
            var dataGroups = EnumExtensions.GetValidOptions<DataGroup>();
            var nextDayses = EnumExtensions.GetValidOptions<ForecastNextDays>();

            return (from stationId in AllStationsId
                from dataGroup in dataGroups
                from nextDays in nextDayses
                select new object[]
                {
                    stationId,
                    dataGroup,
                    nextDays
                }).ToList();
        }

        public static IEnumerable<object[]> GetForecastImageChartMemberData()
        {
            var forecastOptionImages = EnumExtensions.GetValidOptions<ForecastOptionImage>();

            return (from stationId in AllStationsId
                from forecastOptionImage in forecastOptionImages
                select new object[]
                {
                    stationId,
                    forecastOptionImage,
                }).ToList();
        }

        [Theory]
        [MemberData(nameof(GetMemberData))]
        public async Task Get_deve_possui_valor(string stationId, DataGroup dataGroup, ForecastNextDays nextDays)
        {
            using var scope = Provider.CreateScope();
            var forecastService = scope.ServiceProvider.GetService<IForecastService>();
            var values = await forecastService.Get(stationId, dataGroup, nextDays);

            Assert.NotNull(values);
        }

        [Theory]
        [MemberData(nameof(GetForecastImageChartMemberData))]
        public async Task GetForecastImageChart_deve_retornar_valor(string stationId, ForecastOptionImage optionImage)
        {
            using var scope = Provider.CreateScope();
            var forecastService = scope.ServiceProvider.GetService<IForecastService>();

            var values = await forecastService.GetForecastImageChart(stationId, optionImage);

            Assert.NotNull(values);
            
        }
    }
}