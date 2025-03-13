import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Country } from '../models/country.model';
import { environment } from 'src/environments/environment';
import { CountryDetails } from '../models/countryDetails.model';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
  private apiUrl = environment.API_URL;

  constructor(private http: HttpClient) {}

  getAllCountries(name?: string): Observable<Country[]> {
    return this.http.get<Country[]>(`${this.apiUrl}/countries`);
  }

  getCountryDetails(name: string): Observable<CountryDetails> {  
      return this.http.get<CountryDetails>(`${this.apiUrl}/countries/${name}`);
  }
}
