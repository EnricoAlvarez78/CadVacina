import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Grupo } from 'src/app/models/grupo';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GrupoService {

  baseURL = `${environment.mainUrlAPI}v1/grupo`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Grupo[]> {
    return this.http.get<Grupo[]>(this.baseURL);
  }

  getById(id: number): Observable<Grupo> {
    return this.http.get<Grupo>(`${this.baseURL}/${id}`);
  }

  post(model: Grupo) {
    return this.http.post(this.baseURL, model);
  }

  put(model: Grupo) {
    return this.http.put(this.baseURL, model);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
