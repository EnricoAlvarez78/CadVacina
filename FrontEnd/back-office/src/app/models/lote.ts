export class Lote {
  id: number = 0;
  numero: string = '';
  dataRecebimento: string = '';
  fabricante: string = '';
  quantidadeDoses: number = 0;
  diasSegundaDose: number = 0;
  idPosto: number = 0;

  selecionado:boolean = false;

  constructor(id:number, numero:string, selecionado:boolean) {
    this.id = id;
    this.numero = numero;
    this.selecionado = selecionado;
  }
}
