import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Agendamento } from 'src/app/models/agendamento';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AgendamentoService {

  baseURL = `${environment.mainUrlAPI}v1/agendamento`;

  constructor(private http: HttpClient) { }

  put(model: Agendamento) {
    return this.http.put(this.baseURL, model);
  }

  getByCpf(cpf: string): Observable<Agendamento> {
    return this.http.get<Agendamento>(`${this.baseURL}/${cpf}`);
  }
}
