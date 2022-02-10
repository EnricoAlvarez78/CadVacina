import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { ConfirmComponent } from 'src/app/helpers/confirm/confirm.component';
import { Posto } from 'src/app/models/posto';
import { PostoService } from 'src/app/services/administrador/posto.service';

@Component({
  selector: 'app-posto-grid',
  templateUrl: './posto-grid.component.html',
  styleUrls: ['./posto-grid.component.css']
})
export class PostoGridComponent implements OnInit {
  p: number = 1;
  public postos: Array<Posto> = [];

  constructor(private router: Router,
              private simpleModalService:SimpleModalService,
              private postoService:PostoService) { }

  ngOnInit(): void {
    this.carregaTabela();
  }

  carregaTabela() {
    try {
      this.postoService.getAll().subscribe(postos => {
        this.postos = postos
      })
    } catch (error) {
      console.log(error);
    }
  }

  navegarParaPostoFrom(id:number): void {
    this.router.navigate([`/postos/form/${id}`])
  }

  mostraConfirm(id:number, nome:string) {
    let disposable = this.simpleModalService.addModal(ConfirmComponent, {
          title: 'Atenção!',
          message: `Confirma a exclusão do posto ${nome}`
        })
        .subscribe((isConfirmed)=>{
            if(isConfirmed) {
              this.postoService.delete(id).subscribe(() => {
                this.carregaTabela();
              }),
              ((err: any) => {console.log(err)});
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
