import { Component } from '@angular/core';
import { Login } from 'src/app/models/login';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';


@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
  currentSession?: Login | null;

  constructor(private authenticationService: AuthenticationService)
  {
    this.authenticationService.currentSession.subscribe((x) => (this.currentSession = x));
  }

    ngOnInit() {
    }
}
