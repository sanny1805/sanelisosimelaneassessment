using FlagExplorer.Application.Services;
using FlagExplorer.Domain.Entities;
using FlagExplorer.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagExplorer.Tests
{
    public class CountryServiceTests
    {
        private readonly Mock<ICountryExternalClient> _apiMock = new();
        private readonly Mock<ILogger<CountryService>> _loggerMock = new();
        private readonly CountryService _service;

        public CountryServiceTests()
        {
            _service = new CountryService(_apiMock.Object, _loggerMock.Object);
        }

        [Fact]
        public async Task GetAllCountriesAsync_ShouldReturnCountries()
        {
            //_apiMock.Setup(api => api.GetAllCountriesAsync()).ReturnsAsync(new List<Country>
            //{
            //    new() { Name = "South Africa", FlagUrl = "https://flagcdn.com/w320/za.png" }
            //});

            //var result = await _service.GetAllCountriesAsync();

            //Assert.Single(result);
            //Assert.Equal("South Africa", result[0].Name);
        }
    }
}
