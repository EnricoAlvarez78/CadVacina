import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Grupo } from '../models/grupo';

@Injectable({
  providedIn: 'root'
})
export class GrupoService {

  baseURL = `${environment.mainUrlAPI}v1/grupo`;

  constructor(private http: HttpClient) { }

  getByAge(dataNascimento:string | undefined): Observable<Grupo[]> {
    return this.http.get<Grupo[]>(`${this.baseURL}/date/${dataNascimento}`);
  }
}
