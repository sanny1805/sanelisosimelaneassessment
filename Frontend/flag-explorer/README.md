# FlagExplorer - Angular Frontend

A frontend Angular 15 application that displays country flags and details using a clean architecture approach.

## Author

- Name: Saneliso Simelane

## Features

-> Display all country flags in a grid layout (Home Screen).
-> Click on a flag to view detailed country information (Detail Screen).
-> Uses Bootstrap for styling.
-> Follows Clean Architecture principles.
-> Includes unit and integration tests.

## Tech Stack

Angular 15 (Framework)
TypeScript (Language)
Bootstrap 4 (Styling)
RxJS (Reactive programming)
Jasmine & Karma (Testing)

## Project Structure

flag-explorer/
│-- src/
│ ├── app/
│ │ ├── components/ # UI components
│ │ │ ├── home/
│ │ │ │ ├── home.component.ts
│ │ │ │ ├── home.component.html
│ │ │ │ ├── home.component.css
| | | | ├── home.component.spec.ts
│ │ │ ├── country-detail/
│ │ │ │ ├── country-detail.component.ts
│ │ │ │ ├── country-detail.component.html
│ │ │ │ ├── country-detail.component.css
| | | | ├── country-detail.component.spec.ts
│ │ │ ├── header/
│ │ │ │ ├── header.component.ts
│ │ │ │ ├── header.component.html
│ │ │ │ ├── header.component.css
| | | | ├── header.component.spec.ts
│ │ ├── models/ # TypeScript interfaces
│ │ │ ├── country.model.ts
│ │ │ ├── country-details.model.ts
│ │ ├── services/ # API Calls
│ │ │ ├── country.service.ts
│ │ ├── shared/ # Shared Components
│ │ │ ├── components/
│ │ │ │ ├── spinner/
| │ │ │ | ├── spinner.component.ts
| │ │ │ | ├── spinner.component.html
| │ │ │ | ├── spinner.component.css
| | | | | ├── spinner.component.spec.ts
│ ├── assets/ # Static files
│ ├── environments/ # Configurations
│ ├── index.html
│ ├── main.ts
│ ├── styles.css
│-- angular.json # Angular config
│-- package.json # Dependencies
│-- README.md # Project documentation
|-- azure-pipelines.yml # CI/CD Pipeline config
|-- .gitignore # ignore files extentions

## Getting Started

1. Install Dependencies
   Make sure you have Node.js (>=16.0.0) and Angular CLI installed.
   Run the following command inside the project directory:

- npm install

2. Start Development Server
   To run the project locally:

- ng serve
  The app will be available at:
- http://localhost:4200/

3. Run Unit Tests
   To execute unit tests:

- ng test

4. Run Integration Tests
   To execute integration tests:

- ng e2e

## Deployment

To build the project for production:

- ng build --configuration=production
  The output will be available in the /dist folder.

## API Integration

This project consumes a REST API for fetching country details.
Make sure the backend is running and update the apiUrl in:

- src/app/services/country.service.ts
- private apiUrl = 'https://your-backend-url/api/countries';

## UI Preview

### Home Screen

-> Displays country flags in a grid layout.
-> Clicking a flag shows detailed country info.

### Country Detail Screen

-> Shows Country Name, Capital, Population.

## Contributing

Fork the repository

- Create a feature branch (git checkout -b feature-name)
- Commit changes (git commit -m "Added feature")
- Push the branch (git push origin feature-name)
- Open a Pull Request
