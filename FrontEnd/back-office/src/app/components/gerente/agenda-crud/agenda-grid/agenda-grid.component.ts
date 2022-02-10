import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { ConfirmComponent } from 'src/app/helpers/confirm/confirm.component';
import { Agenda } from 'src/app/models/agenda';
import { AgendaService } from 'src/app/services/gerente/agenda.service';

@Component({
  selector: 'app-agenda-grid',
  templateUrl: './agenda-grid.component.html',
  styleUrls: ['./agenda-grid.component.css']
})
export class AgendaGridComponent implements OnInit {
  p: number = 1;
  public agendas: Array<Agenda> = [];

  constructor(private router: Router,
              private simpleModalService:SimpleModalService,
              private agendaService:AgendaService) { }

  ngOnInit(): void {
    this.carregaTabela();
  }

  carregaTabela() {
    try {
      this.agendaService.getAll().subscribe(agendas => {
        this.agendas = agendas
      })
    } catch (error) {
      console.log(error);
    }
  }

  navegarParaFrom(id:number): void {
    this.router.navigate([`/agendas/form/${id}`])
  }

  mostraConfirm(id:number, data:string) {
    let dataSplit  = data.split('-');
    let disposable = this.simpleModalService.addModal(ConfirmComponent, {
          title: 'Atenção!',
          message: `Confirma a exclusão da agenda  ${dataSplit[2]}/${dataSplit[1]}/${dataSplit[0]}`
        })
        .subscribe((isConfirmed)=>{
            if(isConfirmed) {
              this.agendaService.delete(id).subscribe(() => {
                this.carregaTabela();
              }),
              ((err: any) => {console.log(err)});
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
