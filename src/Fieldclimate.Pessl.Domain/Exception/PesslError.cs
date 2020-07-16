using System.Net;

namespace Fieldclimate.Pessl.Domain.Exception
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class PesslError
    {
        public string Method { get; set; }
        public string RequestUri { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string message { get; set; }
    }
}