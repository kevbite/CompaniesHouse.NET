using System;
using System.ComponentModel.DataAnnotations;

namespace CompaniesHouse.Extensions.Microsoft.DependencyInjection
{
    /// <summary>
    /// Options used to configure the Companies House client.
    /// </summary>
    public class CompaniesHouseClientOptions
    {
        /// <summary>
        /// The base <see cref="Uri"/> of the Companies House public data API.
        /// </summary>
        [Required]
        public Uri BaseUri { get; set; } = CompaniesHouseUris.Default;

        /// <summary>
        /// The Companies House API key used to authenticate requests.
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string ApiKey { get; set; } = string.Empty;
    }
}