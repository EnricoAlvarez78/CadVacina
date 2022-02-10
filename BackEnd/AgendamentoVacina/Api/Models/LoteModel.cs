using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Api.Models
{
    [DataContract]
    public partial class LoteModel
    { 
        [DataMember(Name="id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [DataMember(Name="numero")]
        public string Numero { get; set; }

        [Required]
        [MaxLength(10)]
        [DataMember(Name="dataRecebimento")]
        public string DataRecebimento { get; set; }

        [Required]
        [MaxLength(100)]
        [DataMember(Name="fabricante")]
        public string Fabricante { get; set; }

        [Required]
        [DataMember(Name="quantidadeDoses")]
        public int? QuantidadeDoses { get; set; }

        [Required]
        [DataMember(Name="diasSegundaDose")]
        public int? DiasSegundaDose { get; set; }       

        [Required]
        [DataMember(Name="idPosto")]
        public int IdPosto { get; set; }      
    }
}
