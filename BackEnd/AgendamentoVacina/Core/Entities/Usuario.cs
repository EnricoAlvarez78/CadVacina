namespace Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int IdPerfil { get; set; }
        public int? IdPosto { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Posto Posto { get; set; }
    }
}
