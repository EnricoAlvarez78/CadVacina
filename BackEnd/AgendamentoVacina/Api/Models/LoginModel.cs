using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Api.Models
{
    [DataContract]
    public partial class LoginModel
    { 
        [Required]
        [MaxLength(100)]
        [DataMember(Name="email")]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        [DataMember(Name="senha")]
        public string Senha { get; set; }   
        
        [DataMember(Name="nomeUsuario")]
        public string NomeUsuario { get; set; }
        
        [DataMember(Name="idPerfil")]
        public int IdPerfil { get; set; }
        
        [DataMember(Name="idPosto")]
        public int? IdPosto { get; set; }        

        [DataMember(Name="token")]
        public string Token { get; set; }     
    }
}
