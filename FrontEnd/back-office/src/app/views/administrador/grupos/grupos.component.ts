import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-grupos',
  templateUrl: './grupos.component.html',
  styleUrls: ['./grupos.component.css']
})
export class GruposComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToHome(): void {
    this.router.navigate(['/home'])
  }

  navigateToGrupoFrom(): void {
    this.router.navigate(['/grupos/form'])
  }

}
