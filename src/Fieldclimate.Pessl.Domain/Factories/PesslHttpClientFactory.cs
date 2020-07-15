using System.Net.Http;
using System.Net.Http.Headers;

namespace Fieldclimate.Pessl.Domain.Factories
{
    public class PesslHttpClientFactory : IPesslHttpClientFactory
    {
        private readonly PesslConfiguration _pesslConfiguration;
        
        public PesslHttpClientFactory(PesslConfiguration pessl)
        {
            _pesslConfiguration = pessl;
        }

        public HttpClient Create()
        {
            var httpClient = new HttpClient(new MetosHttpHandlerv2(_pesslConfiguration))
            {
                BaseAddress = _pesslConfiguration.BaseAddress
            };

            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return httpClient;
        }
    }
}