using CompaniesHouse;
using CompaniesHouse.Request;
using CompaniesHouse.Response.Search.OfficerSearch;
using CompaniesHouse.Response.Search.CompanySearch;
using CompaniesHouse.Response.Search.DisqualifiedOfficersSearch;
using System;
using System.Linq;
using System.Threading.Tasks;
using CompaniesHouse.Response.Search.AllSearch;

namespace SampleProject
{
    class Program
    {
        static async Task Main( string[] args )
        {
            string api_key = ""; //Add your api key from companies house api here https://developer.companieshouse.gov.uk/developer/applications
            if (!api_key.Any())
            {
                Console.WriteLine( $"No API Key found. Please edit Program.cs to add it in." );
                return;
            }

            Console.WriteLine( $"Starting up - Found this api key: {api_key}" );
            CompaniesHouseClientResponse<CompaniesHouse.Response.Search.AllSearch.AllSearch> result = null;
            string nameToSearchFor = "Bigman";
            var settings = new CompaniesHouseSettings( api_key );
            using (var client = new CompaniesHouseClient( settings ))
            {
                var request = new SearchAllRequest()
                {
                    Query = nameToSearchFor,
                    StartIndex = 0,
                    ItemsPerPage = 10
                };

                result = await client.SearchAllAsync( request );
            }

            DisplayResults( result, nameToSearchFor );
        }

        private static void DisplayResults( CompaniesHouseClientResponse<AllSearch> result, string nameSearchedFor )
        {

            //Show all companies found
            Console.WriteLine( $"{Environment.NewLine}----------------------------------------------" );
            Console.WriteLine( $"Companies found when searching for '{nameSearchedFor}' :" );
            foreach (Company item in result.Data.Items.Where( t => t as Company != null ))
            {
                Console.WriteLine( $"* {item.Title} - {item.Description} - {item.CompanyStatus}" );
            }

            //Show all Officers found
            Console.WriteLine( $"{Environment.NewLine}----------------------------------------------" );
            Console.WriteLine( $"Officers found when searching for '{nameSearchedFor}' :" );
            foreach (Officer item in result.Data.Items.Where( t => t as Officer != null ))
            {
                Console.WriteLine( $"* {item.Title} - {item.Description}" );
            }

            //Show all Disqualified Officers found
            Console.WriteLine( $"{Environment.NewLine}----------------------------------------------" );
            Console.WriteLine( $"Disqualified Officers found when searching for '{nameSearchedFor}' :" );
            foreach (DisqualifiedOfficer item in result.Data.Items.Where( t => t as DisqualifiedOfficer != null ))
            {
                Console.WriteLine( $"* {item.Title}" );
            }
        }
    }
}
