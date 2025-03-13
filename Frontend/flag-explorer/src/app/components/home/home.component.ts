import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Country } from 'src/app/models/country.model';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  countryService = inject(CountryService);
  router = inject(Router);
  countries: Country[] = [];
  isLoading = true;
  errorMessage: string = '';

  ngOnInit() {
    this.countryService.getAllCountries().subscribe({
      next: (data) => {
        this.countries = data;
        this.isLoading = false;
      },
      error: () => {
        this.errorMessage = 'Failed to load countries.';
        this.isLoading = false;
      }
    });
  }

  viewDetails(name: string) {
    this.router.navigate(['/country', name]);
  }
}
