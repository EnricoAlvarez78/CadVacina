import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Grupo } from 'src/app/models/grupo';
import { GrupoService } from 'src/app/services/administrador/grupo.service';

@Component({
  selector: 'app-grupo-form',
  templateUrl: './grupo-form.component.html',
  styleUrls: ['./grupo-form.component.css']
})
export class GrupoFormComponent implements OnInit {
  titulo: string = '';

  grupo: Grupo = new Grupo();

  registerForm!: FormGroup;
  submitted = false;

  get f() { return this.registerForm.controls; }

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private grupoService:GrupoService,
              private simpleModalService:SimpleModalService) {}

  ngOnInit(): void {
    try {
      const id = this.route.snapshot.paramMap.get('id');
      this.titulo = `${id === null ? 'Novo' : 'Editar'} grupo`;

      if (id !== null && parseInt(id, 10) > 0) {
        this.buscaDados(parseInt(id, 10));
      }

      this.registerForm = this.formBuilder.group({
        nome: [this.grupo.nome, Validators.required],
        rua: [this.grupo.idadeMinima, Validators.required],
        ativo: [this.grupo.ativo]
      });

    } catch (error) {
      console.log(error);
    }
  }

  buscaDados(id: number) {
    try {

      this.grupoService.getById(id).subscribe((model) => {
        this.grupo = model;
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  getIdadeMask(): string{
    return '00';
  }

  retornaGrid() {
    this.router.navigate(['/grupos']);
  }

  salvar() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      if (this.route.snapshot.paramMap.get('id') === null) {
        this.grupoService.post(this.grupo).subscribe(() => {
          this.mostraAlert(this.grupo.nome);
        }),
        ((err: any) => {console.log(err)});
      }
      else {
        this.grupoService.put(this.grupo).subscribe(() => {
          this.mostraAlert(this.grupo.nome);
        }),
        ((err: any) => {console.log(err)});
      }
    } catch (error) {
      console.log(error);
    }
  }

  mostraAlert(nome:string) {
    let op = this.route.snapshot.paramMap.get('id') === null  ? 'incluído' : 'alterado';
    let disposable = this.simpleModalService.addModal(AlertComponent, {
          title: 'Atenção!',
          message: `Grupo ${nome} ${op} com sucesso!`
        })
        .subscribe((isOk)=>{
            if(isOk) {
              this.router.navigate(['/grupos']);
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
