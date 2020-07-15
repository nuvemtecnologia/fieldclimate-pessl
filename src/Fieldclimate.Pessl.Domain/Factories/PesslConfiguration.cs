using System;
using System.Diagnostics.CodeAnalysis;

namespace Fieldclimate.Pessl.Domain.Factories
{
    public class PesslConfiguration
    {
        public readonly Uri BaseAddress;
        public readonly string PublicKey;
        public readonly string PrivateKey;

        public PesslConfiguration([NotNull] string publicKey, [NotNull] string privateKey, [NotNull] string baseAddress = "https://api.fieldclimate.com")
        {
            BaseAddress = new Uri(baseAddress);
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}