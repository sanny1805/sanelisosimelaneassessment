import { Country } from './country.model';

export interface CountryDetails extends Country {
  population: number;
  capital: string;
}
