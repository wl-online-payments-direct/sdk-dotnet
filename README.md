# Ingenico Direct .NET SDK

## Introduction

The .NET SDK helps you to communicate with the [Ingenico Direct](https://support.direct.ingenico.com/) Server API. It's primary features are:

* convenient C# wrapper around the API calls and responses
    * marshalls C# request objects to HTTP requests
    * unmarshalls HTTP responses to C# response objects or C# exceptions
* handling of all the details concerning authentication
* handling of required meta data

See the [Ingenico Direct Developer Hub](https://support.direct.ingenico.com/documentation/sdk/server/dotnet/) for more information on how to use the SDK.

## Structure of this repository

This repository consists out of three main components:

1. The source code of the SDK itself: `/Ingenico.Direct.Sdk`
2. The source code of the SDK unit tests: `/Ingenico.Direct.Sdk.Tests`
3. The source code of the example integration tests: `/Ingenico.Direct.Sdk.IntegrationTests`

## Requirements

The .NET SDK supports .NET Framework 4.5 and [.NET Standard](https://docs.microsoft.com/en-us/dotnet/standard/net-standard) 2.0 and 2.1.

### .NET Framework 4.5

When using .NET Framework 4.5, the following packages are rquired:

* [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) 10.0.3 or higher
* [NLog](https://www.nuget.org/packages/NLog/) 4.3.7 or higher
* [System.Collections.Immutable](https://www.nuget.org/packages/System.Collections.Immutable/) 1.2.0 or higher

In addition, the following references are required, which are part of the .NET Framework:
* System.Configuration
* System.Net.Http

### .NET Standard 2.0 and 2.1

When using .NET Standard 2.0 or 2.1, the following packages are rquired:

* [Json.NET](https://www.nuget.org/packages/Newtonsoft.Json/) 12.0.3 or higher
* [NLog](https://www.nuget.org/packages/NLog/) 4.6.8 or higher
* [System.Collections.Immutable](https://www.nuget.org/packages/System.Collections.Immutable/) 1.6.0 or higher
* [System.Configuration.ConfigurationManager](https://www.nuget.org/packages/System.Configuration.ConfigurationManager/) 4.6.0 or higher

## Installation
 
### Release

#### Package Manager

To install the latest .NET SDK release, run the following command in the Package Manager Console (`Tools -> NuGet Package Manager -> Package Manager Console`) in Visual Studio:

	PM> Install-Package Ingenico.Direct.Sdk

#### .NET CLI

To install the latest .NET SDK release, run the following command:

	dotnet add package Ingenico.Direct.Sdk

### Release (Strong-Named)

To install the latest .NET SDK release as a [Strong-Named assembly](https://docs.microsoft.com/en-us/dotnet/framework/app-domains/strong-named-assemblies), follow the instructions above but use `Ingenico.Direct.Sdk.StrongName` instead of `Ingenico.Direct.Sdk`.

## Building the repository

This repository uses [Visual Studio](https://www.visualstudio.com/) 2019 to build. Open `Ingenico.Direct.Sdk.sln` in Visual Studio, and click build.
