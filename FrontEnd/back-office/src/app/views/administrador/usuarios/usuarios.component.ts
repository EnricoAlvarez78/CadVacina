import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  navigateToHome(): void {
    this.router.navigate(['/home'])
  }

  navigateToUsuarioFrom(): void {
    this.router.navigate(['/usuarios/form'])
  }

}
