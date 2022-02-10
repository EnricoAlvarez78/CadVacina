import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { ConfirmComponent } from 'src/app/helpers/confirm/confirm.component';
import { Grupo } from 'src/app/models/grupo';
import { GrupoService } from 'src/app/services/administrador/grupo.service';

@Component({
  selector: 'app-grupo-grid',
  templateUrl: './grupo-grid.component.html',
  styleUrls: ['./grupo-grid.component.css']
})
export class GrupoGridComponent implements OnInit {
  p: number = 1;
  public grupos: Array<Grupo> = [];

  constructor(private router: Router,
              private simpleModalService:SimpleModalService,
              private grupoService:GrupoService) { }

  ngOnInit(): void {
    this.carregaTabela();
  }

  carregaTabela() {
    try {
      this.grupoService.getAll().subscribe(grupos => {
        this.grupos = grupos
      })
    } catch (error) {
      console.log(error);
    }
  }

  navegarParaGrupoFrom(id:number): void {
    this.router.navigate([`/grupos/form/${id}`])
  }

  mostraConfirm(id:number, nome:string) {
    let disposable = this.simpleModalService.addModal(ConfirmComponent, {
          title: 'Atenção!',
          message: `Confirma a exclusão do grupo ${nome}`
        })
        .subscribe((isConfirmed)=>{
            if(isConfirmed) {
              this.grupoService.delete(id).subscribe(() => {
                this.carregaTabela();
              }),
              ((err: any) => {console.log(err)});
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
