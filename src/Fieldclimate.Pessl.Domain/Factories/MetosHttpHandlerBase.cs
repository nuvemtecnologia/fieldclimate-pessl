using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;

namespace Fieldclimate.Pessl.Domain.Factories
{
    public abstract class MetosHttpHandlerBase : DelegatingHandler
    {
        protected readonly PesslConfiguration PesslConfiguration;
        private readonly CultureInfo _enUsCulture = new CultureInfo("en-us");

        protected MetosHttpHandlerBase(PesslConfiguration pesslConfiguration)
        {
            PesslConfiguration = pesslConfiguration;
            ApiUri = new Uri($"{PesslConfiguration.BaseAddress}/v2");
            InnerHandler = new HttpClientHandler();
        }

        protected Uri ApiUri { get; }

        private static string ByteArrayToString(IReadOnlyCollection<byte> ba)
        {
            var hex = new StringBuilder(ba.Count * 2);

            foreach (var b in ba)
                hex.AppendFormat("{0:x2}", b);

            return hex.ToString();
        }

        private byte[] GetPrivateKeyByteArray()
        {
            return Encoding.UTF8.GetBytes(PesslConfiguration.PrivateKey);
        }

        private string GetSignatureString(byte[] signature)
        {
            byte[] privateKeyByteArray = GetPrivateKeyByteArray();

            using var hmac = new HMACSHA256(privateKeyByteArray);
            var signatureBytes = hmac.ComputeHash(signature);
            return ByteArrayToString(signatureBytes);
        }

        protected AuthenticationHeaderValue GetAuthorization(HttpRequestMessage request, string requestRoute, DateTimeOffset date)
        {
            var requestTimeStamp = date.ToString("ddd, dd MMM yyyy HH:mm:ss 'GMT'", _enUsCulture);
            var signatureRawData = GetSignatureRawData(request, requestRoute, requestTimeStamp);
            var signature = Encoding.UTF8.GetBytes(signatureRawData);
            var requestSignatureString = GetSignatureString(signature);
            return new AuthenticationHeaderValue("hmac", $"{PesslConfiguration.PublicKey}:{requestSignatureString}");
        }

        protected abstract string GetSignatureRawData(HttpRequestMessage request, string requestRoute, string requestTimeStamp);
    }
}