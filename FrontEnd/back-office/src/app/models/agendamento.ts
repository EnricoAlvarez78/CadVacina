import { DadosPessoais } from "./dadosPessoais";
import { Endereco } from "./endereco";

export class Agendamento {
  dadosPessoais:DadosPessoais | undefined;
  endereco:Endereco | undefined
  idGrupo: number | undefined;
  idPosto: number | undefined;
  nomePosto: string | undefined;
  data:string | undefined;
  turno:string | undefined;

  constructor(){
    this.dadosPessoais = new DadosPessoais();
    this.endereco = new Endereco();
  }

}
