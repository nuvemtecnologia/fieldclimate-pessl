using System;
using Fieldclimate.Pessl.Domain.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace Fieldclimate.Pessl.Domain.Test
{
    public class FieldClimatePesselTestBase
    {
        protected ServiceProvider Provider { get; }
        protected readonly string StationId = "00002AD4";

        public FieldClimatePesselTestBase()
        {
            var baseAddress = Environment.GetEnvironmentVariable("PESSL_BASE_ADDRESS");
            var publicKey = Environment.GetEnvironmentVariable("PESSL_PUBLIC_KEY");
            var privateKey = Environment.GetEnvironmentVariable("PESSL_PRIVATE_KEY");

            Provider = new ServiceCollection()
                .AddFieldClimatePessl(new PesslConfiguration(publicKey, privateKey, baseAddress))
                .BuildServiceProvider();
        }
    }
}