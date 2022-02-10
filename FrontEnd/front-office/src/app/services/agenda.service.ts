import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Agenda } from '../models/agenda';

@Injectable({
  providedIn: 'root'
})
export class AgendaService {

  baseURL = `${environment.mainUrlAPI}v1/agenda`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Agenda[]> {
    return this.http.get<Agenda[]>(this.baseURL);
  }
}
