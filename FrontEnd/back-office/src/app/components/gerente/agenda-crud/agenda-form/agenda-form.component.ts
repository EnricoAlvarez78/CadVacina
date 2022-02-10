import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Agenda } from 'src/app/models/agenda';
import { Login } from 'src/app/models/login';
import { Lote } from 'src/app/models/lote';
import { AgendaService } from 'src/app/services/gerente/agenda.service';
import { LoteService } from 'src/app/services/gerente/lote.service';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';

@Component({
  selector: 'app-agenda-form',
  templateUrl: './agenda-form.component.html',
  styleUrls: ['./agenda-form.component.css'],
})
export class AgendaFormComponent implements OnInit {
  titulo: string = 'Agenda';
  registerForm!: FormGroup;
  submitted = false;

  agenda: Agenda = new Agenda();
  lotes: Array<Lote> = [];

  get f() {
    return this.registerForm.controls;
  }

  constructor(
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder,
    private agendaService: AgendaService,
    private loteService: LoteService,
    private simpleModalService: SimpleModalService,
    private authenticationService: AuthenticationService
  ) {}

  ngOnInit(): void {
    try {
      const id = this.route.snapshot.paramMap.get('id');
      this.titulo = `${id === null ? 'Nova' : 'Editar'} agenda`;

      if (id !== null && parseInt(id, 10) > 0) {
        this.buscaDados(parseInt(id, 10));
      }

      this.carregarLotes(id);

      this.registerForm = this.formBuilder.group({
        data: [this.agenda.data,  [Validators.required, Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/)]],
        lote: [this.agenda.idLote, [Validators.required, Validators.min(1)]],
        manha: [this.agenda.manha],
        quantidadeManha: [this.agenda.quantidadeManha, [this.requiredIfValidator(() => this.agenda.manha)]],
        tarde: [this.agenda.tarde],
        quantidadeTarde: [this.agenda.quantidadeTarde, [this.requiredIfValidator(() => this.agenda.tarde)]],
      });

    } catch (error) {
      console.log(error);
    }
  }

  requiredIfValidator(predicate: { (): boolean }) {
    return ((formControl: AbstractControl) => {
      if (!formControl.parent) {
        return null;
      }
      if (predicate()) {
        return Validators.required(formControl);
      }
      return null;
    })
  }

  carregarLotes(id: string | null) {
    try {
      this.loteService.getAll().subscribe((objs) => {
        if (id === null) {
          objs.push(new Lote(0, 'Selecione', true));
        }

        this.lotes = objs;
      }),
        (err: any) => {
          console.log(err);
        };
    } catch (error) {
      console.log(error);
    }
  }

  buscaDados(id: number) {
    try {
      this.agendaService.getById(id).subscribe((model) => {
        this.agenda = model;
      }),
        (err: any) => {
          console.log(err);
        };
    } catch (error) {
      console.log(error);
    }
  }

  retornaGrid() {
    this.router.navigate(['/agendas']);
  }

  salvar() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      let idPosto = this.authenticationService.currentSessionValue?.idPosto?.toString();
      this.agenda.idPosto = !!idPosto ? parseInt(idPosto, 10) : 0;

      if (this.route.snapshot.paramMap.get('id') === null) {
        this.agendaService.post(this.agenda).subscribe(() => {
          this.mostraAlert(this.agenda.data);
        }),
          (err: any) => {
            console.log(err);
          };
      } else {
        this.agendaService.put(this.agenda).subscribe(() => {
          this.mostraAlert(this.agenda.data);
        }),
          (err: any) => {
            console.log(err);
          };
      }
    } catch (error) {
      console.log(error);
    }
  }

  mostraAlert(data: string) {
    let dataSplit  = data.split('-');
    let op = this.route.snapshot.paramMap.get('id') === null ? 'incluída' : 'alterada';
    let disposable = this.simpleModalService
      .addModal(AlertComponent, {
        title: 'Atenção!',
        message: `Agenda para ${dataSplit[2]}/${dataSplit[1]}/${dataSplit[0]} ${op} com sucesso!`,
      })
      .subscribe((isOk) => {
        if (isOk) {
          this.router.navigate(['/agendas']);
        }
      });

    setTimeout(() => {
      disposable.unsubscribe();
    }, 10000);
  }

  habilitaQtd(value: string) {
    if (value === 'm' && !this.agenda.manha) {
      this.agenda.quantidadeManha = 0;
    }
    if (value === 't' && !this.agenda.tarde) {
      this.agenda.quantidadeTarde = 0;
    }
  }
}
