using FlagExplorer.Domain.Entities;
using FlagExplorer.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryExternalClient _countryExternalClient;
        private readonly ILogger<CountryService> _logger;

        public CountryService(ICountryExternalClient countryExternalClient, ILogger<CountryService> logger)
        {
            _countryExternalClient = countryExternalClient;
            _logger = logger;
        }

        public async Task<List<Country>> GetAllCountriesAsync()
        {
            try
            {
                _logger.LogInformation("Fetching all countries...");
                return await _countryExternalClient.GetAllCountriesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching all countries.");
                throw new Exception($"Error while fetching all countries.: {ex.Message}");
            }
        }

        public async Task<CountryDetails> GetCountryAsync(string name)
        {
            try
            {
                _logger.LogInformation("Fetching details for {Country}", name);
                return await _countryExternalClient.GetCountryByNameAsync(name);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while fetching specific country details.");
                throw new Exception($"Error while fetching specific country details.: {ex.Message}");
            }
        }
    }
}
