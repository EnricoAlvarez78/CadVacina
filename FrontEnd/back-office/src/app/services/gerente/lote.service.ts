import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Lote } from 'src/app/models/lote';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoteService {
  baseURL = `${environment.mainUrlAPI}v1/lote`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Lote[]> {
    return this.http.get<Lote[]>(this.baseURL);
  }

  getById(id: number): Observable<Lote> {
    return this.http.get<Lote>(`${this.baseURL}/${id}`);
  }

  post(model: Lote) {
    return this.http.post(this.baseURL, model);
  }

  put(model: Lote) {
    return this.http.put(this.baseURL, model);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
