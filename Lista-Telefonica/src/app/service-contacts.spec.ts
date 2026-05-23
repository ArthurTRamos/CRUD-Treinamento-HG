import { TestBed } from '@angular/core/testing';

import { ServiceContacts } from './service-contacts';

describe('ServiceContacts', () => {
  let service: ServiceContacts;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ServiceContacts);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
