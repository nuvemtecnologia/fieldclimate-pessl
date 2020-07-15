using System.Collections.Generic;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;

namespace Fieldclimate.Pessl.Domain.Services
{
    public class SystemService : ServiceBase, ISystemService
    {
        public SystemService(IPesslHttpClientFactory pesslHttpClientFactory) : base(pesslHttpClientFactory)
        {
        }

        public Task<bool> GetStatus()
        {
            const string requestUri = "/system/status";
            return GetAsync<bool>(requestUri);
        }

        public Task<dynamic> GetSensors()
        {
            const string requestUri = "/system/sensors";
            return GetAsync<dynamic>(requestUri);
        }

        public Task<dynamic> GetGroups()
        {
            const string requestUri = "/system/groups";
            return GetAsync<dynamic>(requestUri);
        }

        public Task<dynamic> GetGroupSensors()
        {
            const string requestUri = "/system/group/sensors";
            return GetAsync<dynamic>(requestUri);
        }

        public Task<dynamic> GetTypes()
        {
            const string requestUri = "/system/types";
            return GetAsync<dynamic>(requestUri);
        }

        public Task<IEnumerable<Country>> GetCountries()
        {
            const string requestUri = "/system/countries";
            return GetAsync<IEnumerable<Country>>(requestUri);
        }

        public Task<IEnumerable<SystemDisease>> GetDiseases()
        {
            const string requestUri = "/system/diseases";
            return GetAsync<IEnumerable<SystemDisease>>(requestUri);
        }
    }
}