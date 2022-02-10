import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Lote } from 'src/app/models/lote';
import { LoteService } from 'src/app/services/gerente/lote.service';
import { AuthenticationService } from 'src/app/services/shared/authentication.service';

@Component({
  selector: 'app-lote-form',
  templateUrl: './lote-form.component.html',
  styleUrls: ['./lote-form.component.css']
})
export class LoteFormComponent implements OnInit {
  titulo: string = '';

  lote: Lote = new Lote(0,'',false);

  registerForm!: FormGroup;
  submitted = false;

  get f() { return this.registerForm.controls; }

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private loteService:LoteService,
              private simpleModalService:SimpleModalService,
              private authenticationService: AuthenticationService) {}

  ngOnInit(): void {
    try {
      const id = this.route.snapshot.paramMap.get('id');
      this.titulo = `${id === null ? 'Novo' : 'Editar'} lote`;

      if (id !== null && parseInt(id, 10) > 0) {
        this.buscaDados(parseInt(id, 10));
      }

      this.registerForm = this.formBuilder.group({
        numero: [this.lote.numero, Validators.required],
        dataRecebimento: [this.lote.dataRecebimento, [Validators.required, Validators.pattern(/^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$/)]],
        fabricante: [this.lote.fabricante, Validators.required],
        quantidadeDoses: [this.lote.quantidadeDoses, [Validators.required, Validators.min(1)]],
        diasSegundaDose: [this.lote.diasSegundaDose, [Validators.required, Validators.min(1)]]
      });

    } catch (error) {
      console.log(error);
    }
  }

  buscaDados(id: number) {
    try {

      this.loteService.getById(id).subscribe((model) => {
        this.lote = model;
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  retornaGrid() {
    this.router.navigate(['/lotes']);
  }

  getMaskNumber(): string{
    return '000';
  }

  getMaskDate(): string{
    return '00/00/0000';
  }

  salvar() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      let idPosto = this.authenticationService.currentSessionValue?.idPosto?.toString();
      this.lote.idPosto = !!idPosto ? parseInt(idPosto, 10) : 0;

      if (this.route.snapshot.paramMap.get('id') === null) {
        this.loteService.post(this.lote).subscribe(() => {
          this.mostraAlert(this.lote.numero);
        }),
        ((err: any) => {console.log(err)});
      }
      else {
        this.loteService.put(this.lote).subscribe(() => {
          this.mostraAlert(this.lote.numero);
        }),
        ((err: any) => {console.log(err)});
      }
    } catch (error) {
      console.log(error);
    }
  }

  mostraAlert(numero:string) {
    let op = this.route.snapshot.paramMap.get('id') === null  ? 'incluído' : 'alterado';
    let disposable = this.simpleModalService.addModal(AlertComponent, {
          title: 'Atenção!',
          message: `Lote nº ${numero} ${op} com sucesso!`
        })
        .subscribe((isOk)=>{
            if(isOk) {
              this.router.navigate(['/lotes']);
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
