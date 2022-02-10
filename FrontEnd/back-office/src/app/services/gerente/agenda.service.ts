import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Agenda } from 'src/app/models/agenda';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AgendaService {
  baseURL = `${environment.mainUrlAPI}v1/agenda`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Agenda[]> {
    return this.http.get<Agenda[]>(this.baseURL);
  }

  getById(id: number): Observable<Agenda> {
    return this.http.get<Agenda>(`${this.baseURL}/${id}`);
  }

  post(model: Agenda) {
    return this.http.post(this.baseURL, model);
  }

  put(model: Agenda) {
    return this.http.put(this.baseURL, model);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
