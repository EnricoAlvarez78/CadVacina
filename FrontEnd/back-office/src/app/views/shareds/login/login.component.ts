import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { first } from 'rxjs/operators';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';


@Component({ templateUrl: 'login.component.html' })
export class LoginComponent implements OnInit {
    loginForm!: FormGroup;
    submitted = false;
    error = '';

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        if (this.authenticationService.currentSessionValue) {
            this.router.navigate(['/']);
        }
    }

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', [Validators.required, Validators.email]],
            senha: ['', Validators.required]
        });
    }

    get f() { return this.loginForm.controls; }

    onSubmit() {
        this.submitted = true;
        if (this.loginForm.invalid) {
            return;
        }

        try {
          this.authenticationService.login(this.f.email.value, this.f.senha.value).subscribe(logon => {
            if (!!logon && logon.token !== null) {
              this.router.navigate(['/home']);
            } else {
              this.error = 'Usuário inválido';
            }
          })
        } catch (error) {
          console.log(error);
        }
    }

    esqueciSenha(){
      this.router.navigate(['esqueci-senha']);
    }
}
