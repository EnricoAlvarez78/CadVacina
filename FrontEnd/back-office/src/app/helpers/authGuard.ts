import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../services/shared/authentication.service';


@Injectable({ providedIn: 'root' })
export class AuthGuard implements CanActivate {
    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) { }

    canActivate() {
        const currentSession = this.authenticationService.currentSessionValue;

        if (currentSession !== null && currentSession.token !== null && currentSession.token !== undefined && currentSession.token !== '') {
           return true;
        }

        this.router.navigate(['/login']);
        return false;
    }
}
