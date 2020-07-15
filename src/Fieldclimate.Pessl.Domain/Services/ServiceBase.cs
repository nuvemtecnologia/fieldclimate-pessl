using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.ExtensionsMethods;
using Fieldclimate.Pessl.Domain.Factories;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Services
{
    public abstract class ServiceBase
    {
        private readonly IPesslHttpClientFactory _pesslHttpClientFactory;

        protected ServiceBase(IPesslHttpClientFactory pesslHttpClientFactory)
        {
            _pesslHttpClientFactory = pesslHttpClientFactory;
        }

        protected async Task<T> GetAsync<T>(string requestUri)
        {
            var client = _pesslHttpClientFactory.Create();
            var response = await client.GetAsync(requestUri);

            return await response.DeserializeResponseContentString<T>();
        }

        protected async Task<TReturn> PostAsync<TReturn>(string requestUri, object body)
        {
            var jsonContent = JsonConvert.SerializeObject(body);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            var client = _pesslHttpClientFactory.Create();
            var response = await client.PostAsync(requestUri, contentString);

            return await response.DeserializeResponseContentString<TReturn>();
        }
    }
}