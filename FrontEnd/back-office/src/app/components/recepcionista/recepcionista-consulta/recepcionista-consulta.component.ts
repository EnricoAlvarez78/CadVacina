import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { AgendamentoService } from 'src/app/services/recepcionista/agendamento.service';

@Component({
  selector: 'app-recepcionista-consulta',
  templateUrl: './recepcionista-consulta.component.html',
  styleUrls: ['./recepcionista-consulta.component.css']
})
export class RecepcionistaConsultaComponent implements OnInit {
  titulo: string = 'Busca Agendamento';
  registerForm!: FormGroup;
  submitted = false;

  cpf: string = '';

  get f() {return this.registerForm.controls;}

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private agendamentoService: AgendamentoService,
    private simpleModalService: SimpleModalService) { }

  ngOnInit(): void {
    try {
      this.registerForm = this.formBuilder.group({
        cpf: [this.cpf,[Validators.required,Validators.pattern(/[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}/)]],
      });
    } catch (error) {
      console.error(error);
    }
  }

  getCpfMask(): string {
    return '000.000.000-00';
  }

  consultar() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      this.agendamentoService.getByCpf(this.cpf).subscribe((model) => {
        if (!!model) {
          this.router.navigate([`confirmarDados/${this.cpf}`]);
        } else {
          this.mostraAlert("Não foi encontrado nenhum agendamento para esse cpf.");
        }
      }),
        (err: any) => {
          console.log(err);
        };
    } catch (error) {
      console.log(error);
    }
  }

  mostraAlert(msg: string) {
    let disposable = this.simpleModalService.addModal(AlertComponent, {
        title: 'Atenção!',
        message: msg,
      })
      .subscribe((isOk)=>{
          if(isOk) {
            this.submitted = false;
            this.cpf = '';
          }
      });

    setTimeout(() => {disposable.unsubscribe();}, 10000);
  }
}
