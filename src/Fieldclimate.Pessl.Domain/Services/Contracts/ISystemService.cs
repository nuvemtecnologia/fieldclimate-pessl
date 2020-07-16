using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#system.
    /// ROUTES - SYSTEM.
    /// System routes gives you all information you require to understand the system and what is supported.
    /// </summary>
    public interface ISystemService
    {
        /// <summary>
        /// /system/status.
        /// Checking system status.
        /// </summary>
        /// <returns>System running correctly</returns>
        Task<bool> GetStatus();

        /// <summary>
        /// /system/sensors.
        /// Reading the list of all system sensors. Each sensor has unique sensor code and belongs to group with common specifications.
        /// </summary>
        /// <returns>Supported sensors</returns>
        Task<dynamic> GetSupportedSensors();

        /// <summary>
        /// /system/groups.
        /// Reading the list of all system groups. Each sensor belongs to a group which indicates commons specifications.
        /// </summary>
        /// <returns>Supported sensor groups</returns>
        Task<dynamic> GetSupportedSensorGroups();

        /// <summary>
        /// /system/group/sensors.
        /// Reading the list of all system groups and sensors belonging to them. Each sensor belongs to a group which indicates commons specifications.
        /// </summary>
        /// <returns>Sensors organized in groups</returns>
        Task<IEnumerable<GroupSensor>> GetSensorsOrganizedInGroups();

        /// <summary>
        /// /system/types.
        /// Reading the list of all devices system supports.
        /// </summary>
        /// <returns>Type of devices</returns>
        Task<IEnumerable<DeviceType>> GetTypeOfDevices();

        /// <summary>
        /// /system/countries.
        /// Reading the list of all countries that system supports.
        /// </summary>
        /// <returns>Countries for the languages</returns>
        Task<IEnumerable<Country>> GetCountries();
        
        /// <summary>
        /// /system/timezones.
        /// Reading the list of timezones system supports.
        /// </summary>
        /// <returns>Timezones</returns>
        Task<dynamic> GetTimezones();

        /// <summary>
        /// /system/diseases.
        /// Reading the list of all disease models system currently supports.
        /// Note that KEY returned with model itself is being used to fetch disease model data in requests data, disease, chart and ag-grid.
        /// </summary>
        /// <returns>Disease models</returns>
        Task<IEnumerable<SystemDisease>> GetDiseases();
    }
}