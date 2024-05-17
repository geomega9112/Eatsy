import { TestBed } from '@angular/core/testing';

import { EatsyService } from './eatsy.service';

describe('EatsyService', () => {
  let service: EatsyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EatsyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
