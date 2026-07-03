using CompaniesHouse;
using CompaniesHouse.Request;
using CompaniesHouse.Response;
using CompaniesHouse.Response.CompanyProfile;
using CompaniesHouse.Response.Search.AllSearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using CompaniesHouse.Response.Search.OfficerSearch;
using Microsoft.Extensions.DependencyInjection;
using Officers = CompaniesHouse.Response.Officers.Officers;

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

        var searchResult = await client.SearchAllAsync(new SearchAllRequest
        {
            Query = nameToSearchFor,
            StartIndex = 0,
            ItemsPerPage = 10
        });

        DisplaySearchResults(searchResult, nameToSearchFor);

        var officersResult = await client.GetOfficersAsync(companyNumber);
        DisplayOfficers(officersResult, companyNumber);
    }

    /// <summary>
    /// The recommended way to use the client from an app with an <see cref="IServiceCollection"/>
    /// (ASP.NET Core, worker services, etc.).
    /// </summary>
    private static async Task RunWithDependencyInjectionAsync(string companyNumber)
    {
        var services = new ServiceCollection();
        services.AddCompaniesHouseClient(ApiKey);
        await using var provider = services.BuildServiceProvider();

        var client = provider.GetRequiredService<ICompaniesHouseClient>();

        var result = await client.GetCompanyProfileAsync(companyNumber);
        DisplayCompanyProfile(result, companyNumber);
    }

    private static void DisplaySearchResults(CompaniesHouseResponse<AllSearch> result, string query)
    {
        Console.WriteLine($"\n----------------------------------------------");

        // .Data throws InvalidOperationException on non-success — pattern-match
        // when you need to handle error outcomes explicitly.
        if (result is not CompaniesHouseResponse<AllSearch>.Success { Data: var data })
        {
            Console.WriteLine($"Search failed (HTTP {result.StatusCode}).");
            return;
        }

        Console.WriteLine($"Companies matching '{query}':");
        foreach (var item in data.Items.OfType<Company>())
        {
            // CompanyStatus is a string-backed value type — it never throws on an
            // unrecognised wire value, so we can always describe it safely.
            Console.WriteLine($"  * {item.Title} — {DescribeCompanyStatus(item.CompanyStatus)}");
        }

        Console.WriteLine($"\nOfficers matching '{query}':");
        foreach (var item in data.Items.OfType<Officer>())
            Console.WriteLine($"  * {item.Title} — {item.Description}");

        Console.WriteLine($"\nDisqualified officers matching '{query}':");
        foreach (var item in data.Items.OfType<DisqualifiedOfficer>())
            Console.WriteLine($"  * {item.Title}");
    }

    private static void DisplayOfficers(CompaniesHouseResponse<Officers> result, string companyNumber)
    {
        Console.WriteLine($"\n----------------------------------------------");
        Console.WriteLine($"Officers for {companyNumber}:");

        if (result is not CompaniesHouseResponse<Officers>.Success { Data: var data })
        {
            Console.WriteLine($"  Could not retrieve officers (HTTP {result.StatusCode}).");
            return;
        }

        foreach (var officer in data.Items ?? [])
            Console.WriteLine($"  * {officer.Name}");
    }

    private static void DisplayCompanyProfile(CompaniesHouseResponse<CompanyProfile> result, string companyNumber)
    {
        Console.WriteLine($"\n----------------------------------------------");

        // Switch expression — the compiler guides you through every outcome.
        var summary = result switch
        {
            CompaniesHouseResponse<CompanyProfile>.Success { Data: var company } =>
                $"{company.CompanyName} — {DescribeCompanyStatus(company.CompanyStatus)}",

            CompaniesHouseResponse<CompanyProfile>.NotFound =>
                $"Company {companyNumber} not found.",

            CompaniesHouseResponse<CompanyProfile>.RateLimited { RetryAfter: var delay } =>
                $"Rate limited — retry after {delay}.",

            CompaniesHouseResponse<CompanyProfile>.Unauthorized =>
                "Unauthorized — check your API key.",

            CompaniesHouseResponse<CompanyProfile>.ServerError { StatusCode: var code } =>
                $"Server error {code} — try again later.",

            _ => $"Unexpected response: {result.StatusCode}",
        };

        Console.WriteLine(summary);
    }

    /// <summary>
    /// String-backed value types never throw for an unrecognised value, so this
    /// switch can handle future Companies House statuses gracefully.
    /// </summary>
    private static string DescribeCompanyStatus(CompanyStatus status) => status switch
    {
        _ when status == CompanyStatus.Active    => "active",
        _ when status == CompanyStatus.Dissolved => "dissolved",
        _ when status.IsKnown                   => status.Description ?? status.Value,
        _                                       => $"unknown status ({status.Value})",
    };
}

