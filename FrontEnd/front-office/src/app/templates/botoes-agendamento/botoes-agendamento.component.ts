import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-botoes-agendamento',
  templateUrl: './botoes-agendamento.component.html',
  styleUrls: ['./botoes-agendamento.component.css']
})
export class BotoesAgendamentoComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  cancelar(){
    try {
      this.router.navigate(['home']);
    } catch (error) {
      console.error(error);
    }
  }
}
