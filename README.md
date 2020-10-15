# CompaniesHouse.NET

A simple .NET client wrapper for CompaniesHouse API.

[![install from nuget](http://img.shields.io/nuget/v/CompaniesHouse.svg?style=flat-square)](https://www.nuget.org/packages/CompaniesHouse)
[![downloads](http://img.shields.io/nuget/dt/CompaniesHouse.svg?style=flat-square)](https://www.nuget.org/packages/CompaniesHouse)
[![Build status](https://ci.appveyor.com/api/projects/status/6uv0pemfr07nf4bs/branch/master?svg=true)](https://ci.appveyor.com/project/kevbite/companieshouse-net/branch/master)

## Getting Started

CompaniesHouse.NET can be installed via the package manager console by executing the following commandlet:

```powershell
PM> Install-Package CompaniesHouse
```

Once we have the package installed, we can then create a `CompaniesHouseSettings` with a ApiKey which can be created via the [CompaniesHouse API website](https://developer.companieshouse.gov.uk/developer/applications)

```csharp
var settings = new CompaniesHouseSettings(apiKey);
```

We need to now create a `CompaniesHouseClient` - passing in the settings that we've just created.

```csharp
using(var client = new CompaniesHouseClient(settings))
{
    // Do some work...
}
```

This is the object we'll use going forward for any interaction to the CompaniesHouse API, but don't forget to call `Dispose` after you've finish (or wrap in a `using` block).

## Usage

### Searching for resources

To search for a resource, we first need to create a `SearchRequest` with details of the search we require.

```csharp
var request = new SearchRequest()
{
    Query = "Jay2Base",
    StartIndex = 10,
    ItemsPerPage = 10
};
```

We can then pass the `SearchRequest` object in to the `SearchAllAsync` method and await on the task, this will then return all related resources.

```csharp
var result = await client.SearchAllAsync(request);

foreach (var item in _result.Data.Items)
{
    // Do something...
}
```

If we need to be more precise on the resources we require, we can then pass the request object in to the required search method, either `SearchCompanyAsync` or `SearchOfficerAsync` or `SearchDisqualifiedOfficerAsync` and await on the task.

```csharp
var result1 = await client.SearchCompanyAsync(request);

var result2 = await client.SearchOfficerAsync(request);

var result3 = await client.SearchDisqualifiedOfficerAsync(request);
```

### Getting a company profile

To get a company profile, we pass a company number in to the `GetCompanyProfileAsync` method and await on the task.

```csharp
var result = await client.GetCompanyProfileAsync("10440441");
```

If there was no match for that company number then `null` will be returned.

### Getting company officer list

To get a list of officers for a company, we pass a company number in to the `GetOfficersAsync` method and await on the task.

```csharp
var result = await client.GetOfficersAsync("03977902");
```

We can also pass in some optional parameters of `startIndex` and `pageSize` which will allow us to page the results.

```csharp
var result = await client.GetOfficersAsync("03977902", 10, 10);
```

### Getting company filing history list

To get a list of the filing history for a company, we can pass a company number to the `GetCompanyFilingHistoryAsync` method and await on the task.

```csharp
var result = await client.GetCompanyFilingHistoryAsync("10440441");
```

We can also pass in some optional parameters of `startIndex` and `pageSize` which will allow us to page the results.

```csharp
var result = await client.GetCompanyFilingHistoryAsync("10440441", 10, 10);
```

### Getting company insolvency information

To get the insolvency information for a company, we can pass a company number to the `GetCompanyInsolvencyInformationAsync` method and await on the task.

```csharp
var result = await client.GetCompanyInsolvencyInformationAsync("10440441");
```

If there was no insolvency information for the given company number then `null` will be returned.

### Getting document metadata information

To get the metadata for a document, we can pass document id to the `GetDocumentMetadataAsync` method and await on the task.

```csharp
var result = await client.GetDocumentMetadataAsync("FIxRR8teCKodjkBLRDHv2Cb8y0-nQ7T5G3BEXfWtOu4");
```

If there was no document metadata for the given document id then `null` will be returned.

### Downloading a document

To download a document, we can pass document id to the `DownloadDocumentAsync` method and await on the task.

```csharp
var result = await client.DownloadDocumentAsync("FIxRR8teCKodjkBLRDHv2Cb8y0-nQ7T5G3BEXfWtOu4");
```

If there was no document for the given document id then `null` will be returned.

## Contributing

1. Fork
1. Hack!
1. Pull Request


## Running Unit tests

In order for the integration tests to run, you need an API Key from  [CompaniesHouse API website](https://developer.companieshouse.gov.uk/developer/applications)
Setup API Key in an environment variable called "api_key", and then run the tests.

