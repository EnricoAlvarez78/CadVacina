using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Api.Models
{
    public class EnderecoModel
    {
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