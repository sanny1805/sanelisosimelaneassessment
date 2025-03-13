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
        private readonly Mock<ICountryExternalClient> _mockApi;
        private readonly Mock<ILogger<CountryService>> _mockLogger;
        private readonly CountryService _countryService;

        public CountryServiceTests()
        {
            _mockApi = new Mock<ICountryExternalClient>();
            _mockLogger = new Mock<ILogger<CountryService>>();
            _countryService = new CountryService(_mockApi.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task GetAllCountries_ReturnsListOfCountries()
        {
            // Arrange
            var mockCountries = new List<Country>
            {
                new Country { Name = "South Africa", FlagUrl = "https://flags.com/southafrica.png" },
                new Country { Name = "Lesotho", FlagUrl = "https://flags.com/lesotho.png" }
            };

            _mockApi.Setup(repo => repo.GetAllCountriesAsync()).ReturnsAsync(mockCountries);

            // Act
            var result = await _countryService.GetAllCountriesAsync();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, c => c.Name == "South Africa");
            Assert.Contains(result, c => c.Name == "Lesotho");

            // Verify logging
            _mockLogger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Fetching all countries")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)
                ), Times.Once);
        }

        [Fact]
        public async Task GetCountryDetails_ReturnsCountryDetails()
        {
            // Arrange
            var countryName = "South Africa";
            var countryDetails = new CountryDetails
            {
                Name = "South Africa",
                FlagUrl = "https://flags.com/southafrica.png",
                Population = 60000000,
                Capital = "Pretoria"
            };

            _mockApi.Setup(repo => repo.GetCountryByNameAsync(countryName))
                     .ReturnsAsync(countryDetails);

            // Act
            var result = await _countryService.GetCountryAsync(countryName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(countryName, result.Name);
            Assert.Equal("Pretoria", result.Capital);
            Assert.Equal(60000000, result.Population);

            // Verify logging
            _mockLogger.Verify(
                x => x.Log(
                    It.Is<LogLevel>(logLevel => logLevel == LogLevel.Information),
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains($"Fetching details for {countryName}")),
                    It.IsAny<Exception>(),
                    It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)
                ), Times.Once);
        }
    }
}
