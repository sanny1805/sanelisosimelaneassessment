import { Component, inject, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CountryDetails } from 'src/app/models/countryDetails.model';
import { CountryService } from 'src/app/services/country.service';

@Component({
  selector: 'app-country-detail',
  templateUrl: './country-detail.component.html',
  styleUrls: ['./country-detail.component.css']
})
export class CountryDetailComponent implements OnInit {
  countryService = inject(CountryService);
  route = inject(ActivatedRoute);
  router = inject(Router);
  countryDetail?: CountryDetails;
  isLoading = true;
  errorMessage: string = '';

  ngOnInit() {
    const name = this.route.snapshot.paramMap.get('name');
    if (name) {
      this.countryService.getCountryDetails(name).subscribe({
        next: (data) => {
        this.countryDetail = data;
        this.isLoading = false;
      },
        error: () => {
          this.errorMessage = 'Failed to load country details.'
          this.isLoading = false;
        }
      });
    }
  }

  goBack() {
    this.router.navigate(['/home']);
  }
}
