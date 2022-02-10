import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Posto } from 'src/app/models/posto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostoService {

  baseURL = `${environment.mainUrlAPI}v1/posto`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Posto[]> {
    return this.http.get<Posto[]>(this.baseURL);
  }

  getById(id: number): Observable<Posto> {
    return this.http.get<Posto>(`${this.baseURL}/${id}`);
  }

  post(model: Posto) {
    return this.http.post(this.baseURL, model);
  }

  put(model: Posto) {
    return this.http.put(this.baseURL, model);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
