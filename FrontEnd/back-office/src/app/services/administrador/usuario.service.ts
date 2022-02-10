import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Usuario } from 'src/app/models/usuario';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  baseURL = `${environment.mainUrlAPI}v1/usuario`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Usuario[]> {
    return this.http.get<Usuario[]>(this.baseURL);
  }

  getById(id: number): Observable<Usuario> {
    return this.http.get<Usuario>(`${this.baseURL}/${id}`);
  }

  post(model: Usuario) {
    return this.http.post(this.baseURL, model);
  }

  put(model: Usuario) {
    return this.http.put(this.baseURL, model);
  }

  delete(id: number) {
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  changePassword(email: string | undefined, senha: string) {
    return this.http.put(`${this.baseURL}/alterpassword`, {email, senha});
  }

  resetPassword(email: string | undefined) {
    return this.http.put(`${this.baseURL}/resetpassword`, {email});
  }
}
