import { TestBed } from '@angular/core/testing';

import { ServiceMainPage } from './service-main-page';

describe('ServiceMainPage', () => {
  let service: ServiceMainPage;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceMainPage);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
