import { TestBed, async, inject } from '@angular/core/testing';

import { PreventChangesGuardGuard } from './prevent-changes-guard.guard';

describe('PreventChangesGuardGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PreventChangesGuardGuard]
    });
  });

  it('should ...', inject([PreventChangesGuardGuard], (guard: PreventChangesGuardGuard) => {
    expect(guard).toBeTruthy();
  }));
});
