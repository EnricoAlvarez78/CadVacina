import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AgendamentoService } from 'src/app/services/agendamento.service';
import { PostoService } from 'src/app/services/posto.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  btnAgendaVisible: boolean = false;

  constructor(private router: Router,
              private agendamentoService: AgendamentoService,
              private postoService: PostoService){}

  ngOnInit(): void {
    this.agendamentoService.removeAgendamentoStorage();
    this.habilitaBtnAgendar();
  }

  habilitaBtnAgendar(){
    this.postoService.getAvailables().subscribe(postos => {
      if (!!postos && postos.length > 0) {
        this.btnAgendaVisible = true;
      }
    });
  }

  agendar(){
    this.router.navigate(['dadosPessoais']);
  }

  consultar(){
    this.router.navigate(['consulta']);
  }
}
