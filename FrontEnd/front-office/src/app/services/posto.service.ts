import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Posto } from '../models/posto';

@Injectable({
  providedIn: 'root'
})
export class PostoService {
  baseURL = `${environment.mainUrlAPI}v1/posto`;

  constructor(private http: HttpClient) { }

  getAvailables(): Observable<Posto[]> {
    return this.http.get<Posto[]>(`${this.baseURL}/availables`);
  }
}
