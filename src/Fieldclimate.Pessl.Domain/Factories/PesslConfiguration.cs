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
            if (string.IsNullOrWhiteSpace(publicKey))
                throw new ArgumentNullException(nameof(publicKey));

            if (string.IsNullOrWhiteSpace(privateKey))
                throw new ArgumentNullException(nameof(privateKey));

            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}