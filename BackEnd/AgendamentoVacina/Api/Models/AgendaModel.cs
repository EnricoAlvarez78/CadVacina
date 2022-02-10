using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Api.Models
{
    [DataContract]
    public partial class AgendaModel
    { 
        [DataMember(Name="id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [DataMember(Name="data")]
        public string Data { get; set; }

        [Required]
        [DataMember(Name="manha")]
        public bool Manha { get; set; }

        [Required]
        [DataMember(Name="tarde")]
        public bool Tarde { get; set; }

        [Required]
        [DataMember(Name="quantidadeManha")]
        public int QuantidadeManha { get; set; }

        [Required]
        [DataMember(Name="quantidadeTarde")]
        public int QuantidadeTarde { get; set; }

        [Required]
        [DataMember(Name="idLote")]
        public int IdLote { get; set; }      

        [Required]
        [DataMember(Name="idPosto")]
        public int IdPosto { get; set; }     
    }
}
