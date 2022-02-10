import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Agendamento } from 'src/app/models/agendamento';
import { AgendamentoService } from 'src/app/services/recepcionista/agendamento.service';

@Component({
  selector: 'app-recepcionista-form',
  templateUrl: './recepcionista-form.component.html',
  styleUrls: ['./recepcionista-form.component.css']
})
export class RecepcionistaFormComponent implements OnInit {
  titulo: string = 'Confirmar dados do agendamento';
  registerForm!: FormGroup;
  submitted = false;
  cpf:string = '';

  agendamento:Agendamento = new Agendamento();

  get f() { return this.registerForm.controls; }

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private agendamentoService: AgendamentoService,
    private simpleModalService: SimpleModalService) {}

  ngOnInit(): void {
    try {
      this.cpf = this.route.snapshot.paramMap.get('cpf')!;
      this.buscar(this.cpf);

      this.registerForm = this.formBuilder.group({
        nome: [this.agendamento.dadosPessoais?.nome, Validators.required],
        cpf: [this.agendamento.dadosPessoais?.cpf,[Validators.required,Validators.pattern(/[0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}/),],],
        dataNascimento: [this.agendamento.dadosPessoais?.dataNascimento,[Validators.required,Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/),],],
        telefone: [this.agendamento.dadosPessoais?.telefone, Validators.required],
        mae: [this.agendamento.dadosPessoais?.mae, Validators.required],
        rua: [this.agendamento.endereco?.rua, Validators.required],
        bairro: [this.agendamento.endereco?.bairro, Validators.required],
        cep: [this.agendamento.endereco?.cep, Validators.required],
        cidade: [this.agendamento.endereco?.cidade, Validators.required],
        numero: [this.agendamento.endereco?.numero]
      });

    } catch (error) {
      console.error(error)
    }
  }

  getTelefoneMask(): string {
    let tel = this.agendamento.dadosPessoais?.telefone;
    if (!!tel && tel.length <= 10) {
      return '(00) 0000-00009';
    } else {
      return '(00) 00000-0000';
    }
  }

  getCpfMask(): string {
    return '000.000.000-00';
  }

  getCepMask(): string {
    return '00.000-000';
  }

  buscar(cpf:string){
    try {
      this.agendamentoService.getByCpf(cpf).subscribe((model) => {
        if (!!model) {
          this.agendamento = model;
          this.agendamento.dadosPessoais!.dataNascimento = this.formataDataNascimento(this.agendamento.dadosPessoais?.dataNascimento);
        } else {
          this.mostraAlert("Não foi encontrado nenhum agendamento para esse cpf.");
        }
      }),
      (err: any) => {
        console.log(err);
      };
    } catch (error) {
      console.error(error);
    }
  }

  formataDataNascimento(dt:string|undefined): string{
    if (!!dt) {
      let spl = dt.split('/');
      if (!!spl && spl.length === 3) {
        return `${spl[2]}-${spl[1]}-${spl[0]}`
      }
    }
    return ''
  }

  cancelar(){
    this.router.navigate(['consulta']);
  }

  salvar(){
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      this.agendamentoService.put(this.agendamento).subscribe(() => {
        this.router.navigate([`exibeDados/${this.cpf}`]);
      }), ((err: any) => {console.log(err)});
    } catch (error) {
      console.error(error);
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
          }
      });

    setTimeout(() => {disposable.unsubscribe();}, 10000);
  }
}
