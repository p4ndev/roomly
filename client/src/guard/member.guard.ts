import { ActivatedRouteSnapshot, CanActivateFn, RouterStateSnapshot } from '@angular/router';
import { SessionService } from '../service/session.service';
import { inject } from '@angular/core';

export const memberGuard : CanActivateFn = (
  route : ActivatedRouteSnapshot,
  state : RouterStateSnapshot
) => {
  const sessionService = inject(SessionService);
  return sessionService.isLogged();
};