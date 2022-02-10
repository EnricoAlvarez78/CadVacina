import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lotes',
  templateUrl: './lotes.component.html',
  styleUrls: ['./lotes.component.css']
})
export class LotesComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToHome(): void {
    this.router.navigate(['/home'])
  }

  navigateToFrom(): void {
    this.router.navigate(['/lotes/form'])
  }
}
