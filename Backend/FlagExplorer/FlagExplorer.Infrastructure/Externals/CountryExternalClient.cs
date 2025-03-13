using FlagExplorer.Domain.Entities;
using FlagExplorer.Domain.Interfaces;
using FlagExplorer.Domain.Settings;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlagExplorer.Infrastructure.Externals
{
    public class CountryExternalClient : ICountryExternalClient
    {
        private readonly RestClient _client;
        private readonly ILogger<CountryExternalClient> _logger;

        public CountryExternalClient(ILogger<CountryExternalClient> logger, IOptions<ExternalApiSettings> externalApiSettings) 
        {
            _client = new RestClient(externalApiSettings.Value.CountriesUrl);
            _logger = logger;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            var countries = new List<Country>();
            var request = new RestRequest("/all", Method.Get);
            var response = await _client.ExecuteAsync<List<CountryInfo>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to fetch countries. Status Code: {StatusCode} Error Message: {ErrorMessage}", response.StatusCode, response.ErrorMessage);
                return new List<Country>();
            }

            if (response.Data.Any())
            {
                countries.AddRange(response.Data.Select(countryInfo => new Country
                {
                    Name = countryInfo.Name.Common,
                    FlagUrl = countryInfo.Flags.Png,
                }));
            }

            return countries;
        }

        public async Task<CountryDetails> GetCountryByNameAsync(string name)
        {
            var countryDetails = new CountryDetails();
            var request = new RestRequest($"/name/{name}", Method.Get);
            var response = await _client.ExecuteAsync<List<CountryInfo>>(request);

            if (!response.IsSuccessful || response.Data == null)
            {
                _logger.LogError("Failed to fetch specific country. Status Code: {StatusCode} Error Message: {ErrorMessage}", response.StatusCode, response.ErrorMessage);
            }

            if (response.Data != null && response.Data.Any())
            {
               var countryInfo = response.Data.FirstOrDefault();

                if (countryInfo != null)
                {
                    countryDetails = new CountryDetails
                    {
                        Name = countryInfo.Name.Common,
                        Capital = countryInfo.Capital?.FirstOrDefault() ?? "N/A",
                        Population = countryInfo.Population,
                        FlagUrl= countryInfo.Flags.Png,
                    };
                }

            }

            return countryDetails;
        }
    }
}
