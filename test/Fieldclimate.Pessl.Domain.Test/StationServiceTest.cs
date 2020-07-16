using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class StationServiceTest : FieldClimatePesselTestBase
    {
        [Fact]
        public async Task Ao_buscar_detalhe_da_estacao_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.Get(stationId);
                Assert.NotNull(values);
            }
        }

        [Fact]
        public async Task Ao_buscar_sensores_da_estacao_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.GetSensors(stationId);

                Assert.NotNull(values);
                Assert.NotEmpty(values);
            }
        }

        [Fact]
        public async Task Ao_buscar_nodes_da_estacao_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.GetNodes(stationId);
                Assert.NotNull(values);
            }
        }

        [Fact]
        public async Task Ao_buscar_serials_da_estacao_status_code_deve_ser_sucess()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.GetSerials(stationId);

                Assert.NotNull(values);
            }
        }

        [Theory]
        [InlineData(10, RadiusUnity.Kilometers)]
        [InlineData(10, RadiusUnity.Miles)]
        public async Task Ao_buscar_outras_estacoes_proxima_da_estacao_retorno_deve_possuir_valor(int distance, RadiusUnity radiusUnity)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.GetOtherStationsByProximity(stationId, distance, radiusUnity);

                Assert.NotNull(values);
            }
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        public async Task Ao_buscar_ultimos_eventos_da_estacao_retorno_deve_possuir_valor(int amount)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            foreach (var stationId in StationsId)
            {
                var values = await stationService.GetLastEvents(stationId, amount);
                Assert.NotNull(values);
                Assert.NotEmpty(values);
            }
        }
    }
}