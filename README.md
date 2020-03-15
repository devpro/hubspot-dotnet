# HubSpot .NET

[![Build Status](https://dev.azure.com/devprofr/open-source/_apis/build/status/libraries/hubspot-dotnet-ci?branchName=master)](https://dev.azure.com/devprofr/open-source/_build/latest?definitionId=37&branchName=master)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=devpro.hubspot.dotnet&metric=alert_status)](https://sonarcloud.io/dashboard?id=devpro.hubspot.dotnet)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=devpro.hubspot.dotnet&metric=coverage)](https://sonarcloud.io/dashboard?id=devpro.hubspot.dotnet)

.NET Core wrappers for the [HubSpot](https://www.hubspot.com/) API.

Package | Version | Type
------- | ------- | ----
`Devpro.Hubspot.Abstractions` | [![Version](https://img.shields.io/nuget/v/Devpro.Hubspot.Abstractions.svg)](https://www.nuget.org/packages/Devpro.Hubspot.Abstractions/) | .NET Standard 2.1
`Devpro.Hubspot.Client` | [![Version](https://img.shields.io/nuget/v/Devpro.Hubspot.Client.svg)](https://www.nuget.org/packages/Devpro.Hubspot.Client/) | .NET Standard 2.1

## Requirements

- Have an HubSpot developer account ([create one](https://developers.hubspot.com/))

## How to use

- Have the [NuGet package](https://www.nuget.org/packages/Devpro.Hubspot.Client) in your csproj file (can be done manually, with Visual Studio or through nuget command)

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <ItemGroup>
    <PackageReference Include="Devpro.Hubspot.Client" Version="X.Y.Z" />
  </ItemGroup>
</Project>
```

- Make the code changes to be able to use the library (config & service provider)

```csharp
// implement the configuration interface (for instance in a configuration class in your app project) or use DefaultHubspotClientConfiguration
using Devpro.Hubspot.Client;

public class AppConfiguration : IHubspotClientConfiguration
{
    // explicitely choose where to take the configuration for Hubspot REST API (this is the responibility of the app, not the library)
}

// configure your service provider (for instance in your app Startup class)
using Devpro.Hubspot.Client.DependencyInjection;

var services = new ServiceCollection()
  .AddHubspotClient(Configuration);
```

- Use the repositories (enjoy a simple, yet optimized, HTTP client)

```csharp
using Devpro.Hubspot.Abstractions;

private readonly IContactRepository _contactRepository;

public MyService(IContactRepository contactRepository)
{
    _contactRepository = contactRepository;
}

public async Task GetContacts()
{
    var contacts = await _contactRepository.FindAllAsync();
}
```

## How to build

Once the git repository has been cloned, execute the following commands from the root directory:

```bash
dotnet restore
dotnet build
```

## How to test

For integration tests, to manage the configuration (secrets) you can create a file at the root directory called `Local.runsettings` or define them as environment variables:

```xml
<?xml version="1.0" encoding="utf-8"?>
<RunSettings>
  <RunConfiguration>
    <EnvironmentVariables>
      <Hubspot__Sandbox__BaseUrl>xxx</Hubspot__Sandbox__BaseUrl>
      <Hubspot__Sandbox__ApiKey>xxx</Hubspot__Sandbox__ApiKey>
      <Hubspot__Sandbox__ApplicationId>xxx</Hubspot__Sandbox__ApplicationId>
      <Hubspot__Sandbox__ClientId>xxx</Hubspot__Sandbox__ClientId>
      <Hubspot__Sandbox__ClientSecret>xxx</Hubspot__Sandbox__ClientSecret>
      <Hubspot__Sandbox__RedirectUrl>xxx</Hubspot__Sandbox__RedirectUrl>
    </EnvironmentVariables>
  </RunConfiguration>
</RunSettings>
```

And execute all tests (unit and integration ones):

```bash
dotnet test --settings Local.runsettings
```

## References

- [HubSpot API Overview](https://developers.hubspot.com/docs/overview)
