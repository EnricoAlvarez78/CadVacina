import { Agendamento } from 'src/app/models/agendamento';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DadosPessoais } from 'src/app/models/dadosPessoais';
import { AgendamentoService } from 'src/app/services/agendamento.service';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';

@Component({
  selector: 'app-dados-pessoais',
  templateUrl: './dados-pessoais.component.html',
  styleUrls: ['./dados-pessoais.component.css']
})
export class DadosPessoaisComponent implements OnInit {
  registerForm!: FormGroup;
  submitted = false;

  dadosPessoais: DadosPessoais = new DadosPessoais();

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private agendamentoService: AgendamentoService,
              private simpleModalService: SimpleModalService) { }

  ngOnInit() {
    try {
      this.registerForm = this.formBuilder.group({
        nome: [this.dadosPessoais.nome, Validators.required],
        cpf: [this.dadosPessoais.cpf,[Validators.required,Validators.pattern(/[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}/),],],
        dataNascimento: [this.dadosPessoais.dataNascimento,[Validators.required,Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/),],],
        telefone: [this.dadosPessoais.telefone, Validators.required],
        mae: [this.dadosPessoais.mae, Validators.required]
      });
    } catch (error) {
      console.error(error);
    }
  }

  get f() { return this.registerForm.controls; }

  getTelefoneMask(): string {
    if (this.dadosPessoais.telefone.length <= 10) {
      return '(00) 0000-00009';
    } else {
      return '(00) 00000-0000';
    }
  }

  getCpfMask(): string {
    return '000.000.000-00';
  }

  salvarDadosPessoais() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      this.agendamentoService.getByCpf(this.dadosPessoais.cpf).subscribe((model) => {
        if (!!model) {
          this.mostraAlert("A pessoa portadora desse cpf já esta agendada!");
        } else {
          let agendamento: Agendamento = this.agendamentoService.criaAgendamentoStorage();
          agendamento.dadosPessoais = this.dadosPessoais;
          this.agendamentoService.atualizaAgendamentoStorage(agendamento);

          this.router.navigate(['endereco']);
        }
      }),
      ((err: any) => {console.log(err)});
    } catch (error) {
      console.log(error);
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
