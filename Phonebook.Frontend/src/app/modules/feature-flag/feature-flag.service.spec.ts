import { FeatureFlagService } from './feature-flag.service';
import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { Location } from '@angular/common';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { EnvironmentService, Environment } from 'src/app/services/environment.service';

describe('FeatureFlagService', () => {
  let featureFlagServiceTest: FeatureFlagService;
  let httpMock: HttpTestingController;
  const url = '/assets/defaultFeatureFlags.json';

  beforeEach(() => {
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      imports: [HttpClientTestingModule],
      providers: [
        FeatureFlagService,
        { provide: Location, useClass: LocationMock },
        { provide: EnvironmentService, useClass: MockEnviromentService }
      ]
    }).compileComponents();
    httpMock = TestBed.get(HttpTestingController);
    featureFlagServiceTest = TestBed.get(FeatureFlagService);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(featureFlagServiceTest).toBeTruthy();
  });

  it(' - Feature should be activated', () => {
    const featureFlag = 'test';
    featureFlagServiceTest.get(featureFlag).subscribe(value => {
      expect(value).toBeTruthy();
    });
    const featureFlagRequest = httpMock.expectOne(url);
    featureFlagRequest.flush({ [featureFlag]: 100 });
  });

  it(' - Feature should be deactivated', () => {
    const featureFlag = 'test';
    featureFlagServiceTest.get(featureFlag).subscribe(value => {
      expect(value).toBeFalsy();
    });
    const featureFlagRequest = httpMock.expectOne(url);
    featureFlagRequest.flush({ [featureFlag]: -1 });
  });

  it(' - Feature should be deactivated by default but turned on by user', () => {
    const featureFlag = 'test';
    featureFlagServiceTest.get(featureFlag).subscribe(value => {
      expect(value).toBeFalsy();
    });
    const featureFlagRequest = httpMock.expectOne(url);
    featureFlagRequest.flush({ [featureFlag]: 0 });
  });

  it(' - not specified Flag is deactivated', () => {
    const featureFlag = 'test';
    featureFlagServiceTest.get(featureFlag).subscribe(value => {
      expect(value).toBeFalsy();
    });
    const featureFlagRequest = httpMock.expectOne(url);
    featureFlagRequest.flush({});
  });

  it(' - FeatureFlag.json not found', () => {
    const featureFlag = 'test';
    featureFlagServiceTest.get(featureFlag).subscribe(value => {
      expect(value).toBeFalsy();
    });
    const featureFlagRequest = httpMock.expectOne(url);
    featureFlagRequest.error(new ErrorEvent(''));
  });
});

class LocationMock {
  public prepareExternalUrl(url: string): string {
    return '/' + url;
  }
}

class MockEnviromentService {
  public getEnvironment(): Environment {
    return Environment.production;
  }
}
