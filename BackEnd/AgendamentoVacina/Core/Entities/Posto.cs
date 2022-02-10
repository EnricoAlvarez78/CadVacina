using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Posto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdEndereco { get; set; }

        public virtual Endereco Endereco { get; set; }
        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<Lote> Lotes { get; set; }

        public Posto()
        {
            Agendamentos = new HashSet<Agendamento>();
            Agendas = new HashSet<Agenda>();
            Usuarios = new HashSet<Usuario>();
            Lotes = new HashSet<Lote>();
        }
    }
}