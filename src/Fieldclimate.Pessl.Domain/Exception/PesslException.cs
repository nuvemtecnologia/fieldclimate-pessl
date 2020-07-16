using System;

namespace Fieldclimate.Pessl.Domain.Exception
{
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class PesslException : System.Exception
    {
        [NonSerialized] public readonly PesslError Error;

        public PesslException(PesslError error)
        {
            Error = error;
        }
    }
}