# FlagExplorer - Backend API

A .NET 8 Web API that provides country details, following Clean Architecture principles.

## Author

- Name: Saneliso Simelane

## Features

-> Get all countries with their flags.
-> Get detailed country information, including name, capital, and population.
-> Uses RestSharp for API requests.
-> Implements validation, exception handling, and logging.
-> Unit and integration tests included.
-> Follows Clean Architecture principles.

## Tech Stack

- .NET 8 (Framework)
- C# (Language)
- RestSharp (API Calls)
- Entity Framework Core (Data Access)
- Serilog (Logging)
- xUnit, Moq (Unit & Integration Testing)
- Swagger (OpenAPI 3.0) (API Documentation)

## Project Structure

FlagExplorer/
│-- src/
│ ├── FlagExplorer.Api/ # API Layer
│ │ ├── Controllers/
│ │ │ ├── CountryController.cs
│ │ ├── Program.cs
│ │ ├── appsettings.json  
│ ├── FlagExplorer.Application/ # Business Logic Layer
│ │ ├── Services/
│ │ │ ├── CountryService.cs
│ ├── FlagExplorer.Domain/ # Entities & Core Logic
│ │ ├── Entities/
│ │ │ ├── Country.cs
│ │ │ ├── CountryDetails.cs
│ │ ├── Interfaces/
│ │ │ ├── ICountryService.cs
│ │ │ ├── ICountryExternalClient.cs
│ │ ├── Settings/
│ │ │ ├── ExternalApiSettings.cs
│ ├── FlagExplorer.Infrastructure/ # Data & External Services
│ │ ├── Externals/
│ │ │ ├── CountryExternalClient.cs
│ ├── FlagExplorer.Tests/ # Unit & Integration Tests
│ │ ├── FlagExplorer.Tests/
│ │ │ ├── CountryServiceTests.cs
│ ├── FlagExplorer.sln # Solution File
│-- .gitignore
│-- README.md
|-- azure-pipelines.yml # CI/CD Pipeline config

## Getting Started

1. Prerequisites
   -> Install .NET 8 SDK
   -> Install Visual Studio 2022+

2. Setup
   Clone the repository and navigate to the backend project:

- git clone https://github.com/your-username/FlagExplorer.git
  
3. Configure Environment
   Set API Base URL in appsettings.json:

"ExternalApis": {
"CountriesUrl": "https://restcountries.com/v3.1"
}

4. Run the API
   Run the application using the .NET CLI:

- dotnet run --project src/FlagExplorer.Api

API will be available at:

- https://localhost:7071/swagger

5. Run Unit & Integration Tests
   Run all tests:

- dotnet test

## API Endpoints

1. Get All Countries
   GET /api/countries
   Response:
   [
   {
   "name": "France",
   "flagUrl": "https://flagcdn.com/w320/fr.png"
   },
   {
   "name": "Germany",
   "flagUrl": "https://flagcdn.com/w320/de.png"
   }
   ]

2. Get Country Details
   GET /api/countries/{name}
   Response:
   {
   "name": "France",
   "capital": "Paris",
   "population": 67000000
   "name": "Germany",
   "flagUrl": "https://flagcdn.com/w320/de.png"
   }

## Deployment

CI/CD Pipeline
A GitHub Actions / Azure DevOps pipeline is included to: -> Run unit & integration tests
-> Build the backend application
-> Deploy to Azure Web App

## Contributing

Fork the repository

- Create a feature branch (git checkout -b feature-name)
- Commit changes (git commit -m "Added feature")
- Push the branch (git push origin feature-name)
- Open a Pull Request
