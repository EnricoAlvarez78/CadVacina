import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { MustMatch } from 'src/app/helpers/validacao/must-match.validator';
import { Login } from 'src/app/models/login';
import { UsuarioService } from 'src/app/services/administrador/usuario.service';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  titulo: string = 'Alterar Senha';
  registerForm!: FormGroup;
  submitted = false;

  senha: string = '';
  confirmacao: string = '';

  get f() { return this.registerForm.controls; }

  constructor(private router: Router,
              private formBuilder: FormBuilder,
              private usuarioService:UsuarioService,
              private simpleModalService: SimpleModalService,
              private authenticationService: AuthenticationService) { }

  ngOnInit(): void {
    try {
      this.registerForm = this.formBuilder.group({
        senha: ['', [Validators.required, Validators.minLength(6)]],
        confirmacao: ['', Validators.required],
      }, {
        validator: MustMatch('senha', 'confirmacao')
      });

    } catch (error) {
      console.log(error);
    }
  }

  cancelar(){
    this.router.navigate(['']);
  }

  salvar(){
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }
      let login: Login | null ;
      this.authenticationService.currentSession.subscribe((x) => (login = x));

      this.usuarioService.changePassword(login!.email, this.f.senha.value).subscribe(() => {
        this.mostraAlert();
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  mostraAlert() {
    let disposable = this.simpleModalService.addModal(AlertComponent, {
          title: 'Atenção!',
          message: `Senha alterada com sucesso!`
        })
        .subscribe((isOk)=>{
            if(isOk) {
              this.router.navigate([''])
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }

}
