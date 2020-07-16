using System;
using System.Net;
using System.Threading.Tasks;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Fieldclimate.Pessl.Domain.Test.Base;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class SystemServiceTest : FieldClimatePesselTestBase
    {
        [Fact]
        public async Task GetStatus_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetStatus();

            Assert.True(values);
        }

        [Fact]
        public async Task GetSupportedSensors_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetSupportedSensors();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task GetSupportedSensorGroups_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetSupportedSensorGroups();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task GetSensorsOrganizedInGroups_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();
            var values = await systemService.GetSensorsOrganizedInGroups();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task GetTypeOfDevices_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetTypeOfDevices();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task GetCountries_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetCountries();
            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }

        [Fact]
        public async Task GetDiseases_deve_possuir_valor()
        {
            using var scope = Provider.CreateScope();
            var systemService = scope.ServiceProvider.GetService<ISystemService>();

            var values = await systemService.GetDiseases();

            Assert.NotNull(values);
            Assert.NotEmpty(values);
        }
    }
}