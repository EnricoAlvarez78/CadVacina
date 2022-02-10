using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Api.Models
{
    public class DadosPessoaisModel
    {
        [Required]
        [MaxLength(256)]
        [DataMember(Name="nome")]
        public string Nome { get; set; }

        [Required]
        [MaxLength(14)]
        [DataMember(Name="cpf")]
        public string Cpf { get; set; }


        [Required]
        [MaxLength(10)]
        [DataMember(Name="dataNascimento")]
        public string DataNascimento { get; set; }

        [Required]
        [MaxLength(11)]
        [DataMember(Name="telefone")]
        public string Telefone { get; set; }

        [Required]
        [MaxLength(256)]
        [DataMember(Name="mae")]
        public string Mae { get; set; }
    }
}