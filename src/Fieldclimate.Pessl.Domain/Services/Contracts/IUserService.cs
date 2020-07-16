using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Model;

namespace FieldClimate.Pessl.Domain.Services.Contracts
{
    /// <summary>
    /// https://api.fieldclimate.com/v2/docs/#user
    /// ROUTES - USER
    /// User routes enables you to manage information regarding user you used to authenticate with.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// /user/stations.
        /// Reading list of user devices. Returned value may not be used by your application.
        /// </summary>
        /// <returns>List of stations of a user</returns>
        Task<IEnumerable<Station>> GetStations();

        /// <summary>
        /// /user/licenses.
        /// Reading all licenses that user has for each of his device.
        /// </summary>
        /// <returns>user licenses</returns>
        Task<dynamic> GetLicenses();
    }
}