using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Factories;
using Fieldclimate.Pessl.Domain.Model;
using FieldClimate.Pessl.Domain.Services.Contracts;
using Newtonsoft.Json.Linq;

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

        public async Task<IEnumerable<GroupSensor>> GetGroupSensors()
        {
            const string requestUri = "/system/group/sensors";
            var values = await GetAsync<dynamic>(requestUri);

            var result = new List<GroupSensor>();

            if (!(values is JObject jObject)) return result;

            foreach (var (key, value) in jObject)
            {
                var sensor = new GroupSensor()
                {
                    Group = value.Value<string>("group"),
                    Name = value.Value<string>("name"),
                    Sensors = GetSensorItens(value)
                };

                result.Add(sensor);
            }

            return result;
        }

        private IEnumerable<GroupSensorItem> GetSensorItens(JToken value)
        {
            var result = new List<GroupSensorItem>();
            var sensors = value?.Value<JObject>("sensors");

            if (sensors == null) return result;
            

            foreach (var (key1, value1) in sensors)
            {
                var sensorItem = value1.ToObject<GroupSensorItem>();
                sensorItem.Id = key1;

                result.Add(sensorItem);
            }

            return result;
        }

        public async Task<IEnumerable<SystemType>> GetTypes()
        {
            const string requestUri = "/system/types";
            var values = await GetAsync<dynamic>(requestUri);

            var result = new List<SystemType>();

            if (!(values is JObject jObject)) return result;

            foreach (var (key, value) in jObject)
            {
                result.Add(new SystemType()
                {
                    Key = key,
                    Value = value.ToString()
                });
            }

            return result;
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