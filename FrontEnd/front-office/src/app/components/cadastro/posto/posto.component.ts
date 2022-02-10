import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Agendamento } from 'src/app/models/agendamento';
import { Posto } from 'src/app/models/posto';
import { AgendamentoService } from 'src/app/services/agendamento.service';
import { PostoService } from 'src/app/services/posto.service';

@Component({
  selector: 'app-posto',
  templateUrl: './posto.component.html',
  styleUrls: ['./posto.component.css'],
})
export class PostoComponent implements OnInit {
  registerForm!: FormGroup;
  submitted = false;
  postos: Array<Posto> = [];
  posto: number = 0;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private postoService: PostoService,
    private agendamentoService: AgendamentoService,
    private simpleModalService: SimpleModalService) {}

  ngOnInit(): void {
    try {
      this.carregaPostos();

      this.registerForm = this.formBuilder.group({
        posto: [this.posto, [Validators.required, Validators.min(1)]],
      });
    } catch (error) {
      console.error(error);
    }
  }

  get f() { return this.registerForm.controls; }

  carregaPostos() {
    try {
      this.postoService.getAvailables().subscribe(postos => {

        if (!!postos && postos.length > 0) {
          this.postos = postos;
        } else {
          this.mostraAlert('Não há postos disponivies atualmente. Aguarde uma nova liberação de postos.')
        }
      })
    } catch (error) {
      console.error(error);
    }
  }

  salvarPosto() {
    try {      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      let agendamento: Agendamento = this.agendamentoService.recuperaAgendamentoStorage();
      agendamento.idPosto = parseInt(this.posto.toString(), 10);

      let selecao = this.postos.find(x => x.id === agendamento.idPosto);
      agendamento.nomePosto = `${selecao?.nome}, ${selecao?.rua}, ${selecao?.numero}, ${selecao?.bairro}, ${selecao?.cidade}`

      this.agendamentoService.atualizaAgendamentoStorage(agendamento);

      this.router.navigate(['dataVacinacao']);

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
