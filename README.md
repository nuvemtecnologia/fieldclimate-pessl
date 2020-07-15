# fieldclimate-pessl
A .NETStandard client for the Pessl Instruments GmbH RESTful API.

  - [API V2 - doc](https://api.fieldclimate.com/v2/docs)
  - [fieldclimate](https://www.fieldclimate.com/)
  - [dashboard](https://ng.fieldclimate.com/)

## Usage
 - https://www.nuget.org/packages/XXXX-XXXX/
 - `dotnet add package XXXX-XXXX`

### Configure dependency injection
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

### Inject the interface
```csharp
public class PesslChartController : ControllerBase
{
    private readonly IChartService _chartService;

    public PesslChartController(IChartService chartService)
    {
        _chartService = chartService;
    }
}
```

# Run test
```sh
echo "export PESSL_BASE_ADDRESS=https://api.fieldclimate.com" >> ~/.zshrc && \
echo "export PESSL_PUBLIC_KEY=<YOUR_PESSL_PUBLIC_KEY>" >> ~/.zshrc && \
echo "export PESSL_PRIVATE_KEY=<PESSL_PRIVATE_KEY>" >> ~/.zshrc && \
source ~/.zshrc
```