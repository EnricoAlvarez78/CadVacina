using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Endereco
    {
        public int Id { get; set; }
        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }

        public virtual ICollection<Agendamento> Agendamentos { get; set; }
        public virtual ICollection<Posto> Postos { get; set; }

        public Endereco()
        {
            Agendamentos = new HashSet<Agendamento>();
            Postos = new HashSet<Posto>();
        }

        public Endereco(int id, string rua, string numero, string bairro, string cep, string cidade) 
        {
            this.Id = id;
            this.Rua = rua;
            this.Numero = numero;
            this.Bairro = bairro;
            this.Cep = cep;
            this.Cidade = cidade;            
        }
    }
}