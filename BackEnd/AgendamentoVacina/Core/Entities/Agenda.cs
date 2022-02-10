using System;
using System.Collections.Generic;

#nullable disable

namespace Core.Entities
{
    public class Agenda
    {        
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public bool Manha { get; set; }
        public bool Tarde { get; set; }
        public int? QuantidadeManha { get; set; }
        public int? QuantidadeTarde { get; set; }
        public int IdLote { get; set; }
        public int IdPosto { get; set; }

        public virtual Lote Lote { get; set; }
        public virtual Posto Posto { get; set; }
        
        public Agenda()
        {
        }
    }
}