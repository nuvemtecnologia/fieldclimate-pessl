using System;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;
using Fieldclimate.Pessl.Domain.Factories;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class CameraService : ServiceBase, ICameraService
    {
        /// <inheritdoc />
        public CameraService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        /// <inheritdoc />
        public Task<dynamic> GetPhotosInfo(string stationId)
        {
            var requestUri = $"/camera/{stationId}/photos/info";
            return GetAsync<dynamic>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetPhotos(string stationId, int amount, Camera camera)
        {
            var requestUri = $"/camera/{stationId}/photos/last/{amount}/{(int) camera}";
            return GetAsync<dynamic>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetPhotos(string stationId, DateTimeOffset from, DateTimeOffset to, Camera camera)
        {
            var requestUri = $"/camera/{stationId}/photos/from/{from.ToUnixTimeSeconds()}/to/{to.ToUnixTimeSeconds()}/{(int) camera}";
            return GetAsync<dynamic>(requestUri);
        }
    }
}