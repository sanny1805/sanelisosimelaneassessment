import { ComponentFixture, TestBed, fakeAsync, tick } from '@angular/core/testing';
import { HomeComponent } from './home.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { of } from 'rxjs';
import { CountryService } from 'src/app/services/country.service';

describe('HomeComponent', () => {
  let component: HomeComponent;
  let fixture: ComponentFixture<HomeComponent>;
  let countryService: jasmine.SpyObj<CountryService>;

  beforeEach(async () => {
    const countryServiceMock = jasmine.createSpyObj('CountryService', ['getAllCountries']);

    await TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      declarations: [HomeComponent],
      providers: [{ provide: CountryService, useValue: countryServiceMock }]
    }).compileComponents();

    countryService = TestBed.inject(CountryService) as jasmine.SpyObj<CountryService>;

    countryService.getAllCountries.and.returnValue(of([
      { name: 'France', flagUrl: 'flag-url', population: 1000000, capital: 'Paris' }
    ]));

    fixture = TestBed.createComponent(HomeComponent);
    component = fixture.componentInstance;
  });

  it('should display country flags', fakeAsync(() => {
    component.ngOnInit();
    tick();
    fixture.detectChanges();

    expect(component.countries.length).toBe(1);
    expect(component.countries[0].name).toBe('France');
  }));
});
