import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Perfil } from 'src/app/models/perfil';
import { Usuario } from 'src/app/models/usuario';
import { PerfilService } from 'src/app/services/administrador/perfil.service';
import { UsuarioService } from 'src/app/services/administrador/usuario.service';
import { Posto } from 'src/app/models/posto';
import { PostoService } from 'src/app/services/administrador/posto.service';

@Component({
  selector: 'app-usuario-form',
  templateUrl: './usuario-form.component.html',
  styleUrls: ['./usuario-form.component.css'],
})
export class UsuarioFormComponent implements OnInit {
  titulo: string = 'Usuario';
  registerForm!: FormGroup;
  submitted = false;

  usuario: Usuario = new Usuario();
  perfis: Array<Perfil> = [];
  postos: Array<Posto> = [];

  get f() { return this.registerForm.controls; }

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private usuarioService:UsuarioService,
              private perfilService:PerfilService,
              private postoService:PostoService,
              private simpleModalService: SimpleModalService) {}

  ngOnInit(): void {
    try {
      const id = this.route.snapshot.paramMap.get('id');
      this.titulo = `${id === null ? 'Novo' : 'Editar'} usuário`;

      if (id !== null && parseInt(id, 10) > 0) {
        this.buscaDados(parseInt(id, 10));
      }

      this.carregarPerfis(id);
      this.carregarPostos(id);

      this.registerForm = this.formBuilder.group({
        nome: [this.usuario.nome, Validators.required],
        email: [this.usuario.email, [Validators.required, Validators.email]],
        perfil: [this.usuario.idPerfil, [Validators.required, Validators.min(1)]],
        posto: [this.usuario.idPosto]
      });

    } catch (error) {
      console.log(error);
    }
  }

  buscaDados(id: number) {
    try {

      this.usuarioService.getById(id).subscribe((model) => {
        this.usuario = model;
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  carregarPerfis(id: string | null) {
    try {
      this.perfilService.getAll().subscribe(objs => {

        if (id === null) {
          objs.push(new Perfil(0, 'Selecione', true));
        }

        this.perfis = objs;
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  carregarPostos(id: string | null) {
    try {
      this.postoService.getAll().subscribe(objs => {

        if (id === null) {
          objs.push(new Posto(0, 'Selecione', true));
        }

        this.postos = objs;
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  retornaGrid() {
    this.router.navigate(['/usuarios']);
  }

  salvar() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      if (this.route.snapshot.paramMap.get('id') === null) {
        this.usuarioService.post(this.usuario).subscribe(() => {
          this.mostraAlert(this.usuario.nome);
        }),
        ((err: any) => {console.log(err)});
      }
      else {
        this.usuarioService.put(this.usuario).subscribe(() => {
          this.mostraAlert(this.usuario.nome);
        }),
        ((err: any) => {console.log(err)});
      }
    } catch (error) {
      console.log(error);
    }
  }

  mostraAlert(nome:string) {
    let op = this.route.snapshot.paramMap.get('id') === null  ? 'incluído' : 'alterado';
    let disposable = this.simpleModalService.addModal(AlertComponent, {
          title: 'Atenção!',
          message: `Usuário ${nome} ${op} com sucesso!`
        })
        .subscribe((isOk)=>{
            if(isOk) {
              this.router.navigate(['/usuarios'])
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
