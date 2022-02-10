import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-postos',
  templateUrl: './postos.component.html',
  styleUrls: ['./postos.component.css']
})
export class PostosComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToHome(): void {
    this.router.navigate(['/home'])
  }

  navigateToPostoFrom(): void {
    this.router.navigate(['/postos/form'])
  }

}
