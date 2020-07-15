using System;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class ChartServiceTest : FieldClimatePesselTestBase
    {
        [Theory]
        [InlineData(DataGroup.daily, 2, TimePeriod.days)]
        [InlineData(DataGroup.hourly, 2, TimePeriod.hour)]
        [InlineData(DataGroup.monthly, 2, TimePeriod.months)]
        [InlineData(DataGroup.raw, 2, TimePeriod.weeks)]
        public async Task GetLastHighchart_deve_retornar_valor(DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();

            foreach (var stationId in StationsId)
            {
                var lastChart = await chartService.GetLastHighChart(stationId, dataGroup, numberOfPeriod, period);

                Assert.NotNull(lastChart);
                Assert.NotEmpty(lastChart);
            }
        }


        [Theory]
        [InlineData(DataGroup.daily, 2, TimePeriod.days)]
        [InlineData(DataGroup.hourly, 2, TimePeriod.hour)]
        [InlineData(DataGroup.monthly, 2, TimePeriod.months)]
        [InlineData(DataGroup.raw, 2, TimePeriod.weeks)]
        public async Task GetLastImageChart_deve_retornar_valor(DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();

            foreach (var stationId in StationsId)
            {
                var lastChart = await chartService.GetLastImageChart(stationId, dataGroup, numberOfPeriod, period);

                Assert.NotNull(lastChart);
                Assert.NotEmpty(lastChart);
            }
        }

        [Theory]
        [InlineData(DataGroup.daily, 2, TimePeriod.days)]
        [InlineData(DataGroup.hourly, 2, TimePeriod.hour)]
        [InlineData(DataGroup.monthly, 2, TimePeriod.months)]
        [InlineData(DataGroup.raw, 2, TimePeriod.weeks)]
        public async Task GetLastImagesChart_deve_retornar_valor(DataGroup dataGroup, int numberOfPeriod, TimePeriod period)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();

            foreach (var stationId in StationsId)
            {
                var lastChart = await chartService.GetLastImagesChart(stationId, dataGroup, numberOfPeriod, period);

                Assert.NotNull(lastChart);
                Assert.NotEmpty(lastChart);
            }
        }


        [Theory]
        [InlineData(ForecastOptionImage.meteogram_14day)]
        [InlineData(ForecastOptionImage.meteogram_agro)]
        [InlineData(ForecastOptionImage.meteogram_one)]
        [InlineData(ForecastOptionImage.pictoprint)]
        public async Task GetForecastImageChart_deve_retornar_valor(ForecastOptionImage optionImage)
        {
            using var scope = Provider.CreateScope();
            var chartService = scope.ServiceProvider.GetService<IChartService>();

            foreach (var stationId in StationsId)
            {
                var values = await chartService.GetForecastImageChart(stationId, optionImage);

                Assert.NotNull(values);
                Assert.NotEmpty(values);
            }
        }
    }
}