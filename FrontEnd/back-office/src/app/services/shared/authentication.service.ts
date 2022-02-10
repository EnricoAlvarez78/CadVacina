import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Login } from 'src/app/models/login';


@Injectable({ providedIn: 'root' })
export class AuthenticationService {

  baseURL = `${environment.mainUrlAPI}v1/login`;

  private currentSessionSubject: BehaviorSubject<Login | null>;
  public currentSession: Observable<Login | null>;

  constructor(private http: HttpClient) {
    this.currentSessionSubject = new BehaviorSubject<Login | null>(
      JSON.parse(localStorage.getItem('currentSession') || '{}')
    );
    this.currentSession = this.currentSessionSubject.asObservable();
  }

  public get currentSessionValue(): Login | null {
    return this.currentSessionSubject.value;
  }

  login(email: string, senha: string) {
    return this.http.post<any>(this.baseURL, {email, senha})
      .pipe(
        map((response) => {
          if (response !== null) {
            if (!!response.token) {
              localStorage.setItem('currentSession', JSON.stringify(response));
              this.currentSessionSubject.next(response);
              return response;
            }
          }
          else{
            this.logout();
          }
        })
      );
  }

  logout() {
    localStorage.removeItem('currentSession');
    this.currentSessionSubject.next(null);
  }
}
