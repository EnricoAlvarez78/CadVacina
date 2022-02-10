using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public string Mae { get; set; }
        public DateTime Data { get; set; }
        public string Turno { get; set; }

        public int IdEndereco { get; set; }
        public int IdGrupo { get; set; }
        public int IdPosto { get; set; }
        
        public virtual Endereco Endereco { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual Posto Posto { get; set; }

        public Agendamento(){}           
    }
}