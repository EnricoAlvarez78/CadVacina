import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'
import { SimpleModalService } from 'ngx-simple-modal';
import { ConfirmComponent } from 'src/app/helpers/confirm/confirm.component';
import { Usuario } from 'src/app/models/usuario';
import { UsuarioService } from 'src/app/services/administrador/usuario.service';
@Component({
  selector: 'app-usuario-grid',
  templateUrl: './usuario-grid.component.html',
  styleUrls: ['./usuario-grid.component.css']
})
export class UsuarioGridComponent implements OnInit {
  p: number = 1;
  public usuarios: Array<Usuario> = [];

  constructor(private router: Router,
              private simpleModalService:SimpleModalService,
              private usuarioService:UsuarioService) { }

  ngOnInit(): void {
    this.carregaTabela();
  }

  carregaTabela() {
    try {
      this.usuarioService.getAll().subscribe(usuarios => {
        this.usuarios = usuarios
      })
    } catch (error) {
      console.log(error);
    }
  }

  navegarParaUsuarioFrom(id:number): void {
    this.router.navigate([`/usuarios/form/${id}`])
  }

  mostraConfirm(id:number, nome:string) {
    let disposable = this.simpleModalService.addModal(ConfirmComponent, {
          title: 'Atenção!',
          message: `Confirma a exclusão do usuário ${nome}`
        })
        .subscribe((isConfirmed)=>{
            if(isConfirmed) {
              this.usuarioService.delete(id).subscribe(() => {
                this.carregaTabela();
              }),
              ((err: any) => {console.log(err)});
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
