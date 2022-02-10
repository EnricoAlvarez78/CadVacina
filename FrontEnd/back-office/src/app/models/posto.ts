export class Posto {
  id: number= 0;
  nome: string = '';
  rua: string = '';
  numero: string = '';
  bairro: string = '';
  cep: string = '';
  cidade: string = '';
  selecionado:boolean = false;

  constructor(id:number, nome:string, selecionado:boolean) {
    this.id = id;
    this.nome = nome;
    this.selecionado = selecionado;
  }
}
