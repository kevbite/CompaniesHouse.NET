using CompaniesHouse;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.Response.Search.AllSearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Response.Search.OfficerSearch;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SampleProject;

class Program
{
    // Add your API key from https://developer.company-information.service.gov.uk/
    private const string ApiKey = "";

    static async Task Main()
    {
        if (string.IsNullOrEmpty(ApiKey))
        {
            Console.WriteLine("No API Key found. Please edit Program.cs to add it in.");
            return;
        }

        const string companyNumber = "10440441";
        const string nameToSearchFor = "Bigman";

        await RunWithDirectClientAsync(nameToSearchFor, companyNumber);

        await RunWithDependencyInjectionAsync(companyNumber);
    }

    /// <summary>
    /// The simplest way to use the client: construct <see cref="CompaniesHouseSettings"/> and
    /// <see cref="CompaniesHouseClient"/> directly. Prefer the DI path below in ASP.NET Core apps.
    /// </summary>
    private static async Task RunWithDirectClientAsync(string nameToSearchFor, string companyNumber)
    {
        var settings = new CompaniesHouseSettings(ApiKey);
        using var client = new CompaniesHouseClient(settings);

        var request = new SearchAllRequest
        {
            Query = nameToSearchFor,
            StartIndex = 0,
            ItemsPerPage = 10
        };

        var searchResult = await client.SearchAllAsync(request);
        DisplaySearchResults(searchResult, nameToSearchFor);

        var officers = await client.GetOfficersAsync(companyNumber);
        DisplayOfficers(officers);
    }

    /// <summary>
    /// The recommended way to use the client from an app with an <see cref="IServiceCollection"/>
    /// (ASP.NET Core, worker services, etc.) - see the "CompaniesHouse.Extensions.Microsoft.DependencyInjection" package.
    /// </summary>
    private static async Task RunWithDependencyInjectionAsync(string companyNumber)
    {
        var services = new ServiceCollection();
        services.AddCompaniesHouseClient(ApiKey);
        await using var provider = services.BuildServiceProvider();

        var client = provider.GetRequiredService<ICompaniesHouseClient>();

        var profileResult = await client.GetCompanyProfileAsync(companyNumber);
        DisplayCompanyProfile(profileResult);
    }

    private static void DisplaySearchResults(CompaniesHouseClientResponse<AllSearch> result, string nameSearchedFor)
    {
        Console.WriteLine($"{Environment.NewLine}----------------------------------------------");
        Console.WriteLine($"Companies found when searching for '{nameSearchedFor}' :");
        foreach (var item in result.Data!.Items.OfType<Company>())
        {
            // CompanyStatus is a string-backed value type - it never throws on an unrecognised
            // wire value, so we can always describe it, even for values added after this release.
            Console.WriteLine($"* {item.Title} - {item.Description} - {DescribeCompanyStatus(item.CompanyStatus)}");
        }

        Console.WriteLine($"{Environment.NewLine}----------------------------------------------");
        Console.WriteLine($"Officers found when searching for '{nameSearchedFor}' :");
        foreach (var item in result.Data.Items.OfType<Officer>())
        {
            Console.WriteLine($"* {item.Title} - {item.Description}");
        }

        Console.WriteLine($"{Environment.NewLine}----------------------------------------------");
        Console.WriteLine($"Disqualified Officers found when searching for '{nameSearchedFor}' :");
        foreach (var item in result.Data.Items.OfType<DisqualifiedOfficer>())
        {
            Console.WriteLine($"* {item.Title}");
        }
    }

    private static void DisplayOfficers(CompaniesHouseClientResponse<CompaniesHouse.Response.Officers.Officers> result)
    {
        Console.WriteLine($"{Environment.NewLine}----------------------------------------------");
        Console.WriteLine("Officers:");
        foreach (var officer in result.Data?.Items ?? [])
        {
            Console.WriteLine($"* {officer.Name}");
        }
    }

    private static void DisplayCompanyProfile(CompaniesHouseClientResponse<CompaniesHouse.Response.CompanyProfile.CompanyProfile> result)
    {
        Console.WriteLine($"{Environment.NewLine}----------------------------------------------");
        if (result.Data is null)
        {
            Console.WriteLine($"No company profile found (HTTP {result.StatusCode}).");
            return;
        }

        Console.WriteLine($"Company profile: {result.Data.CompanyName} - {DescribeCompanyStatus(result.Data.CompanyStatus)}");
    }

    /// <summary>
    /// Demonstrates handling an unknown enum value gracefully: string-backed value types never
    /// throw for a value Companies House hasn't announced yet, so unrecognised values fall back
    /// to <see cref="CompanyStatus.Value"/> instead of crashing.
    /// </summary>
    private static string DescribeCompanyStatus(CompanyStatus status) => status switch
    {
        _ when status == CompanyStatus.Active => "active",
        _ when status == CompanyStatus.Dissolved => "dissolved",
        _ when status.IsKnown => status.Description ?? status.Value,
        _ => $"unknown status ({status.Value})",
    };
}
