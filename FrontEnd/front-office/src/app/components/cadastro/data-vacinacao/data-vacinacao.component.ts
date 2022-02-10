import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Agenda } from 'src/app/models/agenda';
import { Agendamento } from 'src/app/models/agendamento';
import { AgendaService } from 'src/app/services/agenda.service';
import { AgendamentoService } from 'src/app/services/agendamento.service';

@Component({
  selector: 'app-data-vacinacao',
  templateUrl: './data-vacinacao.component.html',
  styleUrls: ['./data-vacinacao.component.css']
})
export class DataVacinacaoComponent implements OnInit {
  registerForm!: FormGroup;
  submitted = false;
  agendas: Array<Agenda> = [];
  agenda:number = 0;

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private agendaService:AgendaService,
              private agendamentoService: AgendamentoService) { }

  ngOnInit(): void {
    try {
      this.carregaAgendas();
      this.registerForm = this.formBuilder.group({
        agenda: [this.agenda, [Validators.required, Validators.min(1)]]
      });
    } catch (error) {
      console.error(error);
    }
  }

  get f() {
    return this.registerForm.controls;
  }

  carregaAgendas() {
    try {
      this.agendaService.getAll().subscribe(agendas => {
        let index:number = 1;
        this.agendas.push(new Agenda());
        agendas.forEach(ag => {
          if (ag.manha && ag.quantidadeManha > 0) {
            let newAgenda = new Agenda();
            newAgenda.id = index;
            newAgenda.nomeFormatado = `${this.formataData(ag.data)} - Manhã`;
            this.agendas.push(newAgenda);
            index++;
          }
          if (ag.tarde && ag.quantidadeTarde > 0) {
            let newAgenda = new Agenda();
            newAgenda.id = index;
            newAgenda.nomeFormatado = `${this.formataData(ag.data)} - Tarde`;
            this.agendas.push(newAgenda);
            index++;
          }
        });
      })
    } catch (error) {
      console.error(error);
    }
  }

  formataData(value:string){
    let sp = value.split('-');
    return `${sp[2]}/${sp[1]}/${sp[0]}`
  }

  salvarDataVacinacao() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      let agendamento: Agendamento = this.agendamentoService.recuperaAgendamentoStorage();

      let selecao = this.agendas.find(x => x.id === parseInt(this.agenda.toString(), 10));
      let splt = selecao!.nomeFormatado.split('-');

      agendamento.data = splt[0].trim();
      agendamento.turno = splt[1].trim();

      this.agendamentoService.atualizaAgendamentoStorage(agendamento);

      this.agendamentoService.post(agendamento).subscribe((result) => {
        if (!!result) {
          this.router.navigate(['resultado']);
        } else {
          alert('Ocorreu um erro ao agendar!')
          console.error(result)
        }
      }),
      ((err: any) => {console.log(err)});
    } catch (error) {
      console.error(error);
    }
  }
}
