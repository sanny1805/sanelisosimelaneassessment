using FlagExplorer.Application.Services;
using FlagExplorer.Domain.Entities;
using FlagExplorer.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FlagExplorer.API.Controllers
{
    [ApiController]
    [Route("api/countries")]
    [Produces("application/json")]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }
        /// <summary>
        /// Retrieve all countries.
        /// </summary>
        /// <returns>A list of countries</returns>
        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetAllCountries()
        {
            var countries = await _countryService.GetAllCountriesAsync();
            return Ok(countries);
        }

        /// <summary>
        /// Retrieve details about a specific country.
        /// </summary>
        /// <param name="name">Country name</param>
        /// <returns>Country details</returns>
        [HttpGet("{name}")]
        public async Task<ActionResult<CountryDetails>> GetCountryByName([FromRoute]string name)
        {
            var country = await _countryService.GetCountryAsync(name);

            if (country == null)
            {
                return NotFound(new { message = "Country not found" });
            }
            return Ok(country);
        }

    }
}
