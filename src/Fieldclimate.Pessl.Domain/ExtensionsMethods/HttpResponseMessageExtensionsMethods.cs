using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Fieldclimate.Pessl.Domain.Exception;
using Newtonsoft.Json;

namespace Fieldclimate.Pessl.Domain.ExtensionsMethods
{
    public static class HttpResponseMessageExtensionsMethods
    {
        public static async Task<T> DeserializeResponseContentString<T>(this HttpResponseMessage response)
        {
            var responseString = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode) 
                return response.StatusCode == HttpStatusCode.NoContent ? default : JsonConvert.DeserializeObject<T>(responseString);
           
            var pesslError = JsonConvert.DeserializeObject<PesslError>(responseString);
            pesslError.Method = response.RequestMessage.Method.Method;
            pesslError.RequestUri = response.RequestMessage.RequestUri.ToString();
            pesslError.StatusCode = response.StatusCode;
            throw new PesslException(pesslError);

        }
    }
}