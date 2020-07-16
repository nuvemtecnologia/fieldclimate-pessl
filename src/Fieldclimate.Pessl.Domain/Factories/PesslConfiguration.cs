using System;
using System.Diagnostics.CodeAnalysis;

namespace Fieldclimate.Pessl.Domain.Factories
{
    public class PesslConfiguration
    {
        public Uri BaseAddress => new Uri("https://api.fieldclimate.com");
        public readonly string PublicKey;
        public readonly string PrivateKey;

        public PesslConfiguration([NotNull] string publicKey, [NotNull] string privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}