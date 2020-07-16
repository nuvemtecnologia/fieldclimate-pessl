using System;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Enum;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#cameras
    /// ROUTES - CAMERAS
    /// All the information that is related to your camera device.
    /// </summary>
    public interface ICameraService
    {
        /// <summary>
        /// GET	/camera/{{STATION-ID}}/photos/info
        /// Retrieve min and max date of device data availability. This request can be used to check if device has sent new data which you can retrieve, by just memorizing last date and compare it with current one.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <returns> station information</returns>
        Task<dynamic> GetPhotosInfo(string stationId);

        /// <summary>
        /// GET	/camera/{{STATION-ID}}/photos/last/{{AMOUNT}}/{{CAMERA}}
        /// Retrieve last data that device sends.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="amount">Amount of last pictures you wish to have</param>
        /// <param name="camera"></param>
        /// <returns>Last amount of pictures</returns>
        Task<dynamic> GetPhotos(string stationId, int amount, Camera camera);

        /// <summary>
        /// GET	/camera/{{STATION-ID}}/photos/from/{{FROM-UNIX-TIMESTAMP}}/to/{{TO-UNIX-TIMESTAMP}}/{{CAMERA}}
        /// Retrieve photos between specified period that device sends.
        /// </summary>
        /// <param name="stationId">Unique identifier of a device</param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="camera"></param>
        /// <returns>Retrieve pictures for specified period</returns>
        Task<dynamic> GetPhotos(string stationId, DateTimeOffset from, DateTimeOffset to, Camera camera);
    }
}