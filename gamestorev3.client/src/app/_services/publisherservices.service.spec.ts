import { TestBed } from '@angular/core/testing';

import { PublisherservicesService } from './publisherservices.service';

describe('PublisherservicesService', () => {
  let service: PublisherservicesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PublisherservicesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
