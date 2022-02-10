import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Agendamento } from '../models/agendamento';

@Injectable({
  providedIn: 'root'
})
export class AgendamentoService {

  baseURL = `${environment.mainUrlAPI}v1/agendamento`;

  constructor(private http: HttpClient) { }

  criaAgendamentoStorage(): Agendamento{
    this.removeAgendamentoStorage();
    let agendamento:Agendamento = new Agendamento();
    localStorage.setItem('agendamento', JSON.stringify(agendamento));
    return agendamento;
  }

  removeAgendamentoStorage(): void{
    localStorage.removeItem('agendamento');
  }

  recuperaAgendamentoStorage(): Agendamento{
    let agendamento = localStorage.getItem('agendamento');
    if(!!agendamento){
      return JSON.parse(agendamento)
    }
    return new Agendamento();
  }

  atualizaAgendamentoStorage(agendamento:Agendamento): void{
    this.removeAgendamentoStorage();
    localStorage.setItem('agendamento', JSON.stringify(agendamento));
  }

  post(model: Agendamento) {
    return this.http.post(this.baseURL, model);
  }

  getByCpf(cpf: string): Observable<Agendamento> {
    return this.http.get<Agendamento>(`${this.baseURL}/${cpf}`);
  }
}
