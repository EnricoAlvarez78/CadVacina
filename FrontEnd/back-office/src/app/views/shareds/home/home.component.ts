import { Component } from '@angular/core';
import { Estatistica } from 'src/app/models/estatistica';
import { Login } from 'src/app/models/login';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';
import { EstatisticaService } from 'src/app/services/shared/estatistica.service';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
  currentSession?: Login | null;
  public agendamentosHoje: Array<Estatistica> = [];
  public atendimentoPostos: Array<Estatistica> = [];
  public gruposVacinados: Array<Estatistica> = [];
  public agendamentosTurno: Array<Estatistica> = [];
  public utilizacaoLotes: Array<Estatistica> = [];

  constructor(private authenticationService: AuthenticationService, private estatisticaService: EstatisticaService) {
    this.authenticationService.currentSession.subscribe(
      (x) => (this.currentSession = x)
    );
  }

  ngOnInit(): void {
    this.getAgendamentosHoje();
    this.getAtendimentoPostos();
    this.getAgendamentosTurno();
    this.getGruposVacinados();
    this.getUtilizacaoLotes();
  }

  getAgendamentosHoje() {
    try {
      this.estatisticaService.getAgendamentosHoje().subscribe(agendamentosHoje => {
        this.agendamentosHoje = agendamentosHoje
      })
    } catch (error) {
      console.log(error);
    }
  }

  getAtendimentoPostos() {
    try {
      this.estatisticaService.getAtendimentoPostos().subscribe(atendimentoPostos => {
        this.atendimentoPostos = atendimentoPostos
      })
    } catch (error) {
      console.log(error);
    }
  }

  getGruposVacinados() {
    try {
      this.estatisticaService.getGruposVacinados().subscribe(gruposVacinados => {
        this.gruposVacinados = gruposVacinados
      })
    } catch (error) {
      console.log(error);
    }
  }

  getAgendamentosTurno() {
    try {
      this.estatisticaService.getAgendamentosHoje().subscribe(agendamentosTurno => {
        this.agendamentosTurno = agendamentosTurno
      })
    } catch (error) {
      console.log(error);
    }
  }

  getUtilizacaoLotes() {
    try {
      this.estatisticaService.getUtilizacaoLotes().subscribe(utilizacaoLotes => {
        this.utilizacaoLotes = utilizacaoLotes
      })
    } catch (error) {
      console.log(error);
    }
  }
}
