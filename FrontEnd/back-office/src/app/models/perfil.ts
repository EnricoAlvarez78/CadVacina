export class Perfil {
  id: number = 0;
  nome: string = '';
  selecionado:boolean = false;

  constructor(id:number, nome:string, selecionado:boolean) {
    this.id = id;
    this.nome = nome;
    this.selecionado = selecionado;
  }
}
