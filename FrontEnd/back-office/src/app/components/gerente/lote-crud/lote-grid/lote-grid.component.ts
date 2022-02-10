import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { ConfirmComponent } from 'src/app/helpers/confirm/confirm.component';
import { Lote } from 'src/app/models/lote';
import { LoteService } from 'src/app/services/gerente/lote.service';

@Component({
  selector: 'app-lote-grid',
  templateUrl: './lote-grid.component.html',
  styleUrls: ['./lote-grid.component.css']
})
export class LoteGridComponent implements OnInit {
  p: number = 1;
  public lotes: Array<Lote> = [];

  constructor(private router: Router,
              private simpleModalService:SimpleModalService,
              private loteService:LoteService) { }

  ngOnInit(): void {
    this.carregaTabela();
  }

  carregaTabela() {
    try {
      this.loteService.getAll().subscribe(lotes => {
        this.lotes = lotes
      })
    } catch (error) {
      console.log(error);
    }
  }

  navegarParaFrom(id:number): void {
    this.router.navigate([`/lotes/form/${id}`])
  }

  mostraConfirm(id:number, nome:string) {
    let disposable = this.simpleModalService.addModal(ConfirmComponent, {
          title: 'Atenção!',
          message: `Confirma a exclusão da lote ${nome}`
        })
        .subscribe((isConfirmed)=>{
            if(isConfirmed) {
              this.loteService.delete(id).subscribe(() => {
                this.carregaTabela();
              }),
              ((err: any) => {console.log(err)});
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
