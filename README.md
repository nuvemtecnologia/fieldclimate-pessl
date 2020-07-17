# fieldclimate-pessl
A .NETStandard client for the Pessl Instruments GmbH RESTful API.

![Push nupkg](https://github.com/nuvemtecnologia/fieldclimate-pessl/workflows/Push%20nupkg/badge.svg)

___
## Reference
  - [API V2 - doc](https://api.fieldclimate.com/v2/docs)
  - [fieldclimate](https://www.fieldclimate.com/)
  - [dashboard](https://ng.fieldclimate.com/)

___
## Usage
 - hhttps://www.nuget.org/packages/FieldClimate.Pessl/
 - `dotnet add package FieldClimate.Pessl`

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

___
### Run test
- it is necessary to create the following environment variables


```sh
#zshrc
echo "export PESSL_PUBLIC_KEY=<YOUR_PESSL_PUBLIC_KEY>" >> ~/.zshrc && \
echo "export PESSL_PRIVATE_KEY=<PESSL_PRIVATE_KEY>" >> ~/.zshrc && \
source ~/.zshrc
```

```sh
#bashrc
echo "export PESSL_PUBLIC_KEY=<YOUR_PESSL_PUBLIC_KEY>" >> ~/.bashrc && \
echo "export PESSL_PRIVATE_KEY=<PESSL_PRIVATE_KEY>" >> ~/.bashrc && \
source ~/.bashrc
```
___
### dotnet pack

```sh
nuget setapikey <key>

rm -rf nupkgs && \
dotnet clean -c Release && dotnet build -c Release && \
dotnet pack src/Fieldclimate.Pessl.Domain/Fieldclimate.Pessl.Domain.csproj --no-build --no-restore -c Release -o nupkgs && \
nuget push nupkgs/*.nupkg -Source nuget.org
```
