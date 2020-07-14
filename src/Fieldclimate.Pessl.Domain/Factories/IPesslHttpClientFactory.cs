using System.Net.Http;

namespace Fieldclimate.Pessl.Domain.Factories
{
    public interface IPesslHttpClientFactory
    {
        HttpClient Create();
    }
}