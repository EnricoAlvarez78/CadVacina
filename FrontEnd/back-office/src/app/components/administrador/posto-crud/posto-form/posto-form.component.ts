import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { SimpleModalService } from 'ngx-simple-modal';
import { AlertComponent } from 'src/app/helpers/alert/alert.component';
import { Posto } from 'src/app/models/posto';
import { PostoService } from 'src/app/services/administrador/posto.service';
@Component({
  selector: 'app-posto-form',
  templateUrl: './posto-form.component.html',
  styleUrls: ['./posto-form.component.css']
})
export class PostoFormComponent implements OnInit {
  titulo: string = '';

  posto: Posto = new Posto(0,'',false);

  registerForm!: FormGroup;
  submitted = false;

  get f() { return this.registerForm.controls; }

  constructor(private router: Router,
              private route: ActivatedRoute,
              private formBuilder: FormBuilder,
              private postoService: PostoService,
              private simpleModalService: SimpleModalService) {}

  ngOnInit(): void {
    try {
      const id = this.route.snapshot.paramMap.get('id');
      this.titulo = `${id === null ? 'Novo' : 'Editar'} posto`;

      if (id !== null && parseInt(id, 10) > 0) {
        this.buscaDados(parseInt(id, 10));
      }

      this.registerForm = this.formBuilder.group({
        nome: [this.posto.nome, Validators.required],
        rua: [this.posto.rua, Validators.required],
        bairro: [this.posto.bairro, Validators.required],
        cep: [this.posto.cep, Validators.required],
        cidade: [this.posto.cidade, Validators.required],
        numero: [this.posto.numero]
      });

    } catch (error) {
      console.log(error);
    }
  }

  buscaDados(id: number) {
    try {

      this.postoService.getById(id).subscribe((model) => {
        this.posto = model;
      }),
      ((err: any) => {console.log(err)});

    } catch (error) {
      console.log(error);
    }
  }

  getCepMask(): string{
    return '00.000-000';
  }

  retornaGrid() {
    this.router.navigate(['/postos']);
  }

  salvar() {
    try {
      this.submitted = true;

      if (this.registerForm.invalid) {
        return;
      }

      if (this.route.snapshot.paramMap.get('id') === null) {
        this.postoService.post(this.posto).subscribe(() => {
          this.mostraAlert(this.posto.nome);
        }),
        ((err: any) => {console.log(err)});
      }
      else {
        this.postoService.put(this.posto).subscribe(() => {
          this.mostraAlert(this.posto.nome);
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
          message: `Posto ${nome} ${op} com sucesso!`
        })
        .subscribe((isOk)=>{
            if(isOk) {
              this.router.navigate(['/postos']);
            }
        });

    setTimeout(()=>{ disposable.unsubscribe(); },10000);
  }
}
