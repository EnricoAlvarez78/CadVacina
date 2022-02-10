import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from './models/login';
import { AuthenticationService } from './services/shared/authentication.service';

@Component({ selector: 'app-root', templateUrl: 'app.component.html' })
export class AppComponent {
  currentSession?: Login | null;

  constructor(private authenticationService: AuthenticationService)
  {
    this.authenticationService.currentSession.subscribe((x) => (this.currentSession = x));
  }
}
