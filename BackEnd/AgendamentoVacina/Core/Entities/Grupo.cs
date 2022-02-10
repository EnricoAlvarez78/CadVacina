using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Grupo
    {        
        public int Id { get; set; }
        public string Nome { get; set; }
        public int IdadeMinima { get; set; }
        public bool Ativo { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }

        public Grupo()
        {
            Agendamentos = new HashSet<Agendamento>();
        }

        public Grupo(int id, string nome, int idadeMinima, bool ativo) 
        {
            this.Id = id;
            this.Nome = nome;
            this.IdadeMinima = idadeMinima;               
            this.Ativo = ativo;
        }
    }
}