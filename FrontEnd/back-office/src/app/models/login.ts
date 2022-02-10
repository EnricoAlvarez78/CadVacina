export class Login {
  email: string | undefined;
  senha: string | undefined;
  nomeUsuario: string | undefined;
  idPerfil: number | undefined;
  idPosto?: number | null = null;
  token?: string;
}
