import { TestBed } from '@angular/core/testing';

import { UserphotoService } from './userphoto.service';

describe('UserphotoService', () => {
  let service: UserphotoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserphotoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
