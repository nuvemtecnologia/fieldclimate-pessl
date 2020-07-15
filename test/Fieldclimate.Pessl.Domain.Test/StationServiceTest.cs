using System;
using System.Collections.Generic;
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
        public async Task Ao_buscar_stations_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetAll();
            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task Ao_buscar_detalhe_da_estacao_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.Get(StationId);
            Assert.NotNull(values);
        }

        [Theory]
        [InlineData(DataGroup.daily)]
        [InlineData(DataGroup.hourly)]
        [InlineData(DataGroup.monthly)]
        [InlineData(DataGroup.raw)]
        public async Task Ao_buscar_dado_da_estacao_por_periodo_retorno_deve_possuir_valor(DataGroup dataGroup)
        {
            var from = new DateTime(2020, 1, 1);
            var to = new DateTime(2020, 2, 1);

            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetData(StationId, dataGroup, from, to);
            Assert.NotNull(values);
        }

        [Theory]
        [InlineData(DataGroup.daily)]
        [InlineData(DataGroup.hourly)]
        [InlineData(DataGroup.monthly)]
        [InlineData(DataGroup.raw)]
        public async Task Ao_buscar_ultimo_dado_da_estacao_retorno_deve_possuir_valor(DataGroup dataGroup)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetLastData(StationId, dataGroup);

            Assert.NotNull(values);
        }

        [Fact]
        public async Task Ao_buscar_sensores_da_estacao_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetSensors(StationId);

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task Ao_buscar_nodes_da_estacao_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetNodes(StationId);

            Assert.NotNull(values);
        }

        [Fact]
        public async Task Ao_buscar_serials_da_estacao_status_code_deve_ser_sucess()
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetSerials(StationId);

            Assert.NotNull(values);
        }

        [Theory]
        [InlineData(10, RadiusUnity.Kilometers)]
        [InlineData(10, RadiusUnity.Miles)]
        public async Task Ao_buscar_outras_estacoes_proxima_da_estacao_retorno_deve_possuir_valor(int distance, RadiusUnity radiusUnity)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetOtherStationsByProximity(StationId, distance, radiusUnity);
            
            Assert.NotNull(values);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(100)]
        public async Task Ao_buscar_ultimos_eventos_da_estacao_retorno_deve_possuir_valor(int amount)
        {
            using var scope = Provider.CreateScope();
            var stationService = scope.ServiceProvider.GetService<IStationService>();

            var values = await stationService.GetLastEvents(StationId, amount);
            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }
    }
}