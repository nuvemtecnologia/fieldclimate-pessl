using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class UserService : ServiceBase, IUserService
    {
        /// <inheritdoc />
        public UserService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        /// <inheritdoc />
        public Task<IEnumerable<Station>> GetStations()
        {
            const string requestUri = "/user/stations";
            return GetAsync<IEnumerable<Station>>(requestUri);
        }

        /// <inheritdoc />
        public Task<dynamic> GetLicenses()
        {
            const string requestUri = "/user/licenses";
            return GetAsync<dynamic>(requestUri);
        }
    }
}