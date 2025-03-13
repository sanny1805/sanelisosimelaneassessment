import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { CountryDetailComponent } from './country-detail.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';
import { CountryService } from 'src/app/services/country.service';
import { ActivatedRoute } from '@angular/router';

describe('CountryDetailComponent', () => {
  let component: CountryDetailComponent;
  let fixture: ComponentFixture<CountryDetailComponent>;
  let countryService: jasmine.SpyObj<CountryService>;

  beforeEach(async () => {
    const countryServiceMock = jasmine.createSpyObj('CountryService', ['getCountryByName']);

    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [CountryDetailComponent],
      providers: [
        { provide: CountryService, useValue: countryServiceMock },
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: { paramMap: { get: () => 'France' } },
          },
        },
      ],
    }).compileComponents();

    countryService = TestBed.inject(CountryService) as jasmine.SpyObj<CountryService>;

    countryService.getAllCountries.and.returnValue(of([
      {
        name: 'France',
        flagUrl: 'flag-url',
        population: 67000000,
        capital: 'Paris',
      }
    ]));

    fixture = TestBed.createComponent(CountryDetailComponent);
    component = fixture.componentInstance;
  });

  it('should fetch the first country from the response and display it', fakeAsync(() => {
    component.ngOnInit();
    tick();
    fixture.detectChanges();

    expect(component.country).toBeTruthy();
    expect(component.country?.name).toBe('France');
    expect(component.country?.capital).toBe('Paris');
    expect(component.country?.population).toBe(67000000);
  }));
});
