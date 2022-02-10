import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Agendamento } from 'src/app/models/agendamento';
import { AgendamentoService } from 'src/app/services/recepcionista/agendamento.service';

@Component({
  selector: 'app-recepcionista-exibe',
  templateUrl: './recepcionista-exibe.component.html',
  styleUrls: ['./recepcionista-exibe.component.css']
})
export class RecepcionistaExibeComponent implements OnInit {

  agendamento:Agendamento = new Agendamento();
  nome: string | undefined = '' ;
  cpf: string | undefined = '';
  dataProximo: string | undefined = '';

  constructor(private router: Router,
              private route: ActivatedRoute,
              private agendamentoService: AgendamentoService) { }

  ngOnInit(): void {
      this.buscar(this.route.snapshot.paramMap.get('cpf')!);
  }

  buscar(cpf:string){
    try {
      this.agendamentoService.getByCpf(cpf).subscribe((model) => {
        if (!!model) {
          this.agendamento = model;
          this.nome = this.agendamento.dadosPessoais?.nome;
          this.cpf = this.agendamento.dadosPessoais?.cpf;
          this.dataProximo = `${this.agendamento.data}`;
        }
      }),
      (err: any) => {
        console.log(err);
      };
    } catch (error) {
      console.error(error);
    }
  }

  voltar(){
    this.router.navigate(['consulta']);
  }
}
