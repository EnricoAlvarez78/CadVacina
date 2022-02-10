import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Agendamento } from 'src/app/models/agendamento';
import { Grupo } from 'src/app/models/grupo';
import { AgendamentoService } from 'src/app/services/agendamento.service';
import { GrupoService } from 'src/app/services/grupo.service';

@Component({
  selector: 'app-grupo',
  templateUrl: './grupo.component.html',
  styleUrls: ['./grupo.component.css'],
})
export class GrupoComponent implements OnInit {
  registerForm!: FormGroup;
  submitted = false;

  grupos: Array<Grupo> = [];
  grupo:number = 0;
  agendamento: Agendamento = new Agendamento();

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private grupoService:GrupoService,
              private agendamentoService: AgendamentoService,
              private simpleModalService: SimpleModalService) {}

  ngOnInit(): void {
    try {
      this.agendamento = this.agendamentoService.recuperaAgendamentoStorage();

      this.carregaGrupos();

      this.registerForm = this.formBuilder.group({
        grupo: [this.grupo, [Validators.required, Validators.min(1)]],
      });
    } catch (error) {
      console.error(error);
    }
  }

  get f() {
    return this.registerForm.controls;
  }

  carregaGrupos() {
    try {
      this.grupoService.getByAge(this.agendamento.dadosPessoais?.dataNascimento).subscribe(grupos => {
        if (!!grupos && grupos.length > 0) {
          this.grupos = grupos
        } else {
          this.mostraAlert('Não há grupos liberados para sua idade. Aguarde uma nova liberação de grupos de prioridade.')
        }
      })
    } catch (error) {
      console.error(error);
    }
  }

  salvarGrupo() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      this.agendamento.idGrupo = parseInt(this.grupo.toString(), 10);
      this.agendamentoService.atualizaAgendamentoStorage(this.agendamento);

      this.router.navigate(['posto']);

    } catch (error) {
      console.error(error);
    }
  }

  mostraAlert(msg:string) {
    let disposable = this.simpleModalService.addModal(AlertComponent, {
          title: 'Atenção!',
          message: msg
        })
        .subscribe((isOk)=>{
            if(isOk) {
              this.router.navigate(['home']);
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
