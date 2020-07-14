using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Fieldclimate.Pessl.Domain.Factories
{
    public class MetosHttpHandlerv2 : MetosHttpHandlerBase
    {
        public MetosHttpHandlerv2(PesslConfiguration pesslConfiguration) : base(pesslConfiguration)
        {
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var date = DateTimeOffset.UtcNow;
            var requestRoute = request.RequestUri.AbsolutePath;
            var combinedPath = ApiUri.AbsolutePath + requestRoute;
            request.RequestUri = new Uri(ApiUri, combinedPath);

            request.Headers.Date = date;
            request.Headers.Authorization = GetAuthorization(request, requestRoute, date);

            return base.SendAsync(request, cancellationToken);
        }

        protected override string GetSignatureRawData(HttpRequestMessage request, string requestRoute, string requestTimeStamp)
        {
            return $"{request.Method.Method}{requestRoute}{requestTimeStamp}{PesslConfiguration.PublicKey}";
        }
    }
}