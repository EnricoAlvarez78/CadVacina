using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Api.Models
{
    [DataContract]
    public partial class UsuarioModel
    { 
        [DataMember(Name="id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(256)]
        [DataMember(Name="nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(100)]
        [DataMember(Name="email")]
        public string Email { get; set; }

        [Required]
        [DataMember(Name="idPerfil")]
        public int IdPerfil { get; set; }   

        [MaxLength(20)]
        [DataMember(Name="nomePerfil")]
        public string NomePerfil { get; set; }   

        [DataMember(Name="idPosto")]
        public int? IdPosto { get; set; }     
    }
}
