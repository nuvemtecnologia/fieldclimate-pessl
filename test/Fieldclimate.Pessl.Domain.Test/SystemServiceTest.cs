using System;
using System.Net;
using System.Threading.Tasks;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class SystemServiceTest : FieldClimatePesselTestBase
    {
        [Fact]
        public async Task Ao_buscar_status_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetStatus();

            Assert.True(values);
        }

        [Fact]
        public async Task Ao_buscar_sensores_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetSupportedSensors();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task Ao_buscar_grupos_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetSupportedSensorGroups();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task Ao_buscar_grupo_de_sensores_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();
            var values = await systemService.GetSensorsOrganizedInGroups();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task Ao_buscar_types_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetTypeOfDevices();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task Ao_buscar_paises_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetCountries();
            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task Ao_buscar_doencas_retorno_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetDiseases();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }
    }
}