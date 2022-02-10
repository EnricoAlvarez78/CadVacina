import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Agendamento } from 'src/app/models/agendamento';
import { Endereco } from 'src/app/models/endereco';
import { AgendamentoService } from 'src/app/services/agendamento.service';

@Component({
  selector: 'app-endereco',
  templateUrl: './endereco.component.html',
  styleUrls: ['./endereco.component.css']
})
export class EnderecoComponent implements OnInit {
  registerForm!: FormGroup;
  submitted = false;

  endereco: Endereco = new Endereco();

  constructor(private formBuilder: FormBuilder,
              private router: Router,
              private agendamentoService: AgendamentoService) { }

  ngOnInit(): void {
    try {
      this.registerForm = this.formBuilder.group({
        rua: [this.endereco.rua, Validators.required],
        bairro: [this.endereco.bairro, Validators.required],
        cep: [this.endereco.cep, Validators.required],
        cidade: [this.endereco.cidade, Validators.required],
        numero: [this.endereco.numero]
      });
    } catch (error) {
      console.error(error);
    }
  }

  get f() { return this.registerForm.controls; }

  getCepMask(): string {
    return '00.000-000';
  }

  salvarEndereco() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      let agendamento: Agendamento = this.agendamentoService.recuperaAgendamentoStorage();
      agendamento.endereco = this.endereco;
      this.agendamentoService.atualizaAgendamentoStorage(agendamento);

      this.router.navigate(['grupo']);
    } catch (error) {
      console.error(error);
    }
  }

}
