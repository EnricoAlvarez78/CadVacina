import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forbidden-error',
  templateUrl: './forbidden-error.component.html',
  styleUrls: ['./forbidden-error.component.css']
})
export class ForbiddenErrorComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  voltar() {
    this.router.navigate(['']);
  }
}
