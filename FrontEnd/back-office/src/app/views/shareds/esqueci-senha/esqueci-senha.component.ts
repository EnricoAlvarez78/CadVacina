import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { UsuarioService } from 'src/app/services/administrador/usuario.service';

@Component({
  selector: 'app-esqueci-senha',
  templateUrl: './esqueci-senha.component.html',
  styleUrls: ['./esqueci-senha.component.css']
})
export class EsqueciSenhaComponent implements OnInit {
  titulo: string = 'Esqueci minha senha';
  registerForm!: FormGroup;
  submitted = false;

  email: string = '';

  get f() { return this.registerForm.controls; }

  constructor(private router: Router,
    private formBuilder: FormBuilder,
    private usuarioService:UsuarioService,
    private simpleModalService: SimpleModalService) { }

  ngOnInit(): void {
    try {
      this.registerForm = this.formBuilder.group({
        email: [this.email, [Validators.required, Validators.email]],
      });

    } catch (error) {
      console.log(error);
    }
  }

  cancelar() {
    this.router.navigate(['']);
  }

  enviar() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      this.usuarioService.resetPassword(this.email).subscribe(() => {
        this.mostraAlert(this.email);
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  mostraAlert(email:string) {
    let disposable = this.simpleModalService.addModal(AlertComponent, {
          title: 'Atenção!',
          message: `Um e-mail foi enviado para ${email} com uma nova senha temporária.`
        })
        .subscribe((isOk)=>{
            if(isOk) {
              this.router.navigate([''])
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }

}
