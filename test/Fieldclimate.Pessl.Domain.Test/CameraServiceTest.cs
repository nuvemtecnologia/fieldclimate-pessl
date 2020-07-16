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
    public class CameraServiceTest : FieldClimatePesselTestBase
    {
        private static readonly DateTimeOffset From = new DateTime(2020, 1, 1);
        private static readonly DateTimeOffset To = new DateTime(2020, 1, 30);

        // [Theory]
        // [MemberData(nameof(GetAllStationIdInfoMemberData))]
        public async Task GetPhotosInfo_deve_retornar_valor(string stationId)
        {
            using var scope = Provider.CreateScope();
            var cameraService = scope.ServiceProvider.GetService<ICameraService>();


            var lastChart = await cameraService.GetPhotosInfo(stationId);

            Assert.NotNull(lastChart);
           
        }

        // [Theory]
        // [MemberData(nameof(GetPhotosMemberData))]
        public async Task GetPhotos_deve_retornar_valor(string stationId, int amount, Camera camera)
        {
            using var scope = Provider.CreateScope();
            var cameraService = scope.ServiceProvider.GetService<ICameraService>();

            var lastChart = await cameraService.GetPhotos(stationId, amount, camera);

            Assert.NotNull(lastChart);
           
        }

        // [Theory]
        // [MemberData(nameof(GetPhotosByPeriodoMemberData))]
        public async Task GetPhotosByPeriodo_deve_retornar_valor(string stationId, DateTimeOffset from, DateTimeOffset to, Camera camera)
        {
            using var scope = Provider.CreateScope();
            var cameraService = scope.ServiceProvider.GetService<ICameraService>();

            var lastChart = await cameraService.GetPhotos(stationId, from, to, camera);

            Assert.NotNull(lastChart);
           
        }
        
        public static IEnumerable<object[]> GetPhotosMemberData()
        {
            var allCameraValues = EnumExtensions.GetValidOptions<Camera>();

            return (from stationId in CameraStationsId
                from camera in allCameraValues
                select new object[]
                {
                    stationId,
                    1,
                    camera
                }).ToList();
        }

        public static IEnumerable<object[]> GetPhotosByPeriodoMemberData()
        {
            var allCameraValues = EnumExtensions.GetValidOptions<Camera>();

            return (from stationId in CameraStationsId
                from camera in allCameraValues
                select new object[]
                {
                    stationId,
                    From,
                    To,
                    camera
                }).ToList();
        }
    }
}