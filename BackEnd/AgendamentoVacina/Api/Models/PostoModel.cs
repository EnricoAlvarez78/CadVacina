using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Api.Models
{
    [DataContract]
    public partial class PostoModel
    { 
        [DataMember(Name="id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DataMember(Name="nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(256)]
        [DataMember(Name="rua")]
        public string Rua { get; set; }

        [MaxLength(10)]
        [DataMember(Name="numero")]
        public string Numero { get; set; }

        [Required]
        [MaxLength(100)]
        [DataMember(Name="bairro")]
        public string Bairro { get; set; }

        [MaxLength(10)]
        [DataMember(Name="cep")]
        public string Cep { get; set; }

        [Required]
        [MaxLength(100)]
        [DataMember(Name="cidade")]
        public string Cidade { get; set; }        
    }
}
