import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/app/models/login';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  currentSession?: Login | null;

  constructor(private router: Router,
    private authenticationService: AuthenticationService) {
      this.authenticationService.currentSession.subscribe((x) => (this.currentSession = x));
    }

  ngOnInit(): void {
  }

  logout() {
    this.authenticationService.logout();
    this.router.navigate(['/login']);
  }
}
