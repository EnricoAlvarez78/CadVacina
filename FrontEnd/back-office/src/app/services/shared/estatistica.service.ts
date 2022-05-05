import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Estatistica } from 'src/app/models/estatistica';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EstatisticaService {

  baseURL = `${environment.mainUrlAPI}v1/estatistica`;

  constructor(private http: HttpClient) { }

  getAgendamentosHoje(): Observable<Estatistica[]> {
    return this.http.get<Estatistica[]>(`${this.baseURL}/agendamentoshoje`);
  }

  getAtendimentoPostos(): Observable<Estatistica[]> {
    return this.http.get<Estatistica[]>(`${this.baseURL}/atendimentopostos`);
  }

  getAgendamentosTurno(): Observable<Estatistica[]> {
    return this.http.get<Estatistica[]>(`${this.baseURL}/agendamentosturno`);
  }

  getGruposVacinados(): Observable<Estatistica[]> {
    return this.http.get<Estatistica[]>(`${this.baseURL}/gruposvacinados`);
  }

  getUtilizacaoLotes(): Observable<Estatistica[]> {
    return this.http.get<Estatistica[]>(`${this.baseURL}/utilizacaolotes`);
  }
}
