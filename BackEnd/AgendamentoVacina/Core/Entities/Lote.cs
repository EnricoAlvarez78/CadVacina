using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Lote
    {
        public int Id { get; set; }
        public int IdPosto { get; set; }
        public string Numero { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string Fabricante { get; set; }
        public int DiasSegundaDose { get; set; }
        public int QuantidadeDoses { get; set; }
        public int DosesReservadas { get; set; }
        public int DosesAplicadas { get; set; }

        public virtual Posto Posto { get; set; }
        public virtual ICollection<Agenda> Agendas { get; set; }

        public Lote()
        {
            Agendas = new HashSet<Agenda>();
        }

        public Lote(int id, string numero, DateTime dataRecebimento, string fabricante, int quantidadeDoses, int diasSegundaDose) 
        {
            this.Id = id;
                this.Numero = numero;
                this.DataRecebimento = dataRecebimento;
                this.Fabricante = fabricante;
                this.QuantidadeDoses = quantidadeDoses;
                this.DiasSegundaDose = diasSegundaDose;
               
        }
    }
}