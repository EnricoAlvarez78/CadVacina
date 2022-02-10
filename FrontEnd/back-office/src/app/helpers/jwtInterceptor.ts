import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from '../services/shared/authentication.service';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {
    constructor(private authenticationService: AuthenticationService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const currentSession = this.authenticationService.currentSessionValue;
        const isLoggedIn = currentSession && currentSession.token;
        const isApiUrl = request.url.startsWith(environment.mainUrlAPI);
        if (isLoggedIn && isApiUrl) {
          if(currentSession !== null){
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${currentSession.token}`
                }
            });
          }
        }

        return next.handle(request);
    }
}
