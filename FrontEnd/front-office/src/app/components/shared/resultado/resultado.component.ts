import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Agendamento } from 'src/app/models/agendamento';
import { AgendamentoService } from 'src/app/services/agendamento.service';
import { DadosPessoais } from './../../../models/dadosPessoais';

@Component({
  selector: 'app-resultado',
  templateUrl: './resultado.component.html',
  styleUrls: ['./resultado.component.css']
})
export class ResultadoComponent implements OnInit {

  agendamento: Agendamento = new Agendamento();

  nome: string | undefined = '' ;
  cpf: string | undefined = '';
  data: string | undefined = '';
  posto: string | undefined = '';

  constructor(private router: Router,
              private agendamentoService: AgendamentoService) { }

  ngOnInit(): void {
    this.preemcheResultado();
  }

  voltar(){
    try {
      this.router.navigate(['home']);
    } catch (error) {
      console.error(error);
    }
  }

  preemcheResultado(){
    this.agendamento = this.agendamentoService.recuperaAgendamentoStorage();
    this.nome = this.agendamento.dadosPessoais?.nome;
    this.cpf = this.agendamento.dadosPessoais?.cpf;
    this.data = `${this.agendamento.data} - ${this.agendamento.turno}`;
    this.posto = this.agendamento.nomePosto;
  }

}
