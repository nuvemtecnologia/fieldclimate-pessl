using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class DiseaseServiceTest : FieldClimatePesselTestBase
    {
        private static DateTimeOffset from = new DateTime(2020, 1, 1);
        private static DateTimeOffset to = new DateTime(2020, 1, 30);
        private static string[] defaultDiseases =
        {
            "SugarBeet/BeetCast",
            "SugarBeet/Cercopri"
        };

        public static IEnumerable<object[]> AllGetLastParameters()
        {
            var allDataGroupValues = EnumExtensions.GetValidOptions<DataGroup>();
            var allTimePeriodValues = EnumExtensions.GetValidOptions<TimePeriod>();

            var memberData = new List<object[]>();

            foreach (var dataGroup in allDataGroupValues)
            {
                foreach (var timePeriod in allTimePeriodValues)
                {
                    memberData.Add(new object[] {dataGroup, 2, timePeriod, defaultDiseases});
                    memberData.Add(new object[] {dataGroup, 2, timePeriod, null});
                }
            }

            return memberData;
        }

        public static IEnumerable<object[]> AllGetParameters()
        {
            var allDataGroupValues = EnumExtensions.GetValidOptions<DataGroup>();

            var memberData = new List<object[]>();

            foreach (var dataGroup in allDataGroupValues)
            {
                memberData.Add(new object[] {dataGroup, from, to, defaultDiseases});
                memberData.Add(new object[] {dataGroup, from, to, null});
            }

            return memberData;
        }

        [Theory]
        [MemberData(nameof(AllGetLastParameters))]
        public async Task GetLast_deve_retornar_valor(DataGroup dataGroup, int numberOfEvents, TimePeriod period, string[] diseases)
        {
            using var scope = Provider.CreateScope();
            var diseaseService = scope.ServiceProvider.GetService<IDiseaseService>();

            foreach (var stationId in StationsId)
            {
                var values = await diseaseService.GetLast(stationId, dataGroup, numberOfEvents, period, diseases);

                Assert.NotNull(values);
            }
        }

        [Theory]
        [MemberData(nameof(AllGetParameters))]
        public async Task Get_deve_retornar_valor(DataGroup dataGroup, DateTimeOffset from, DateTimeOffset to, string[] diseases)
        {
            using var scope = Provider.CreateScope();
            var diseaseService = scope.ServiceProvider.GetService<IDiseaseService>();

            foreach (var stationId in StationsId)
            {
                var values = await diseaseService.Get(stationId, dataGroup, from, to, diseases);

                Assert.NotNull(values);
            }
        }
    }
}