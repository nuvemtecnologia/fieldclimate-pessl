using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.ExtensionsMethods;
using Fieldclimate.Pessl.Domain.Factories;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.Services
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class ServiceBase
    {
        private readonly IPesslHttpClientFactory _pesslHttpClientFactory;

        protected ServiceBase(IPesslHttpClientFactory pesslHttpClientFactory)
        {
            _pesslHttpClientFactory = pesslHttpClientFactory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestUri"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected async Task<T> GetAsync<T>(string requestUri)
        {
            var client = _pesslHttpClientFactory.Create();
            var response = await client.GetAsync(requestUri);

            return await response.DeserializeResponseContentString<T>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="requestUri"></param>
        /// <param name="body"></param>
        /// <typeparam name="TReturn"></typeparam>
        /// <returns></returns>
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