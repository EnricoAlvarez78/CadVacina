import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Perfil } from 'src/app/models/perfil';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PerfilService {

  baseURL = `${environment.mainUrlAPI}v1/perfil`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Perfil[]> {
    return this.http.get<Perfil[]>(this.baseURL);
  }
}
