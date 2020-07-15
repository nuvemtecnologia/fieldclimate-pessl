# fieldclimate-pessl
A .NETStandard client for the Pessl Instruments GmbH RESTful API.

  - [API V2 - doc](https://api.fieldclimate.com/v2/docs)
  - [fieldclimate](https://www.fieldclimate.com/)
  - [dashboard](https://ng.fieldclimate.com/)

## Usage
 - https://www.nuget.org/packages/XXXX-XXXX/
 - `dotnet add package XXXX-XXXX`

```csharp
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var pesslConfiguration = new PesslConfiguration("YOUR_PUBLIC_KEY", "YOUR_PRIVATE_KEY");

        services
            .AddFieldClimatePessl(pesslConfiguration);
    }
}
```