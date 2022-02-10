using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Api.Models
{
    [DataContract]
    public partial class GrupoModel
    { 
        [DataMember(Name="id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataMember(Name="nome")]
        public string Nome { get; set; }

        [Required]
        [DataMember(Name="idadeMinima")]
        public int? IdadeMinima { get; set; }

        [Required]
        [DataMember(Name="ativo")]
        public bool Ativo { get; set; }
    }
}
