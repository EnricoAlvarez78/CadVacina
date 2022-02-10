using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Api.Models
{ 
    [DataContract]
    public partial class AgendamentoModel 
    { 

        [DataMember(Name="id")]
        public int? Id { get; set; }

        [Required]
        [DataMember(Name="dadosPessoais")]
        public DadosPessoaisModel DadosPessoais { get; set; }

        [Required]
        [DataMember(Name="endereco")]
        public EnderecoModel Endereco { get; set; }

        [Required]
        [DataMember(Name="idGrupo")]
        public int IdGrupo { get; set; }

        [Required]
        [DataMember(Name="idPosto")]
        public int IdPosto { get; set; }        

        [Required]
        [DataMember(Name="data")]
        public string Data { get; set; }    

        [Required]
        [DataMember(Name="turno")]
        public string Turno { get; set; }

        [DataMember(Name="nomePosto")]
        public string NomePosto { get; set; }

        public AgendamentoModel()
        {
            DadosPessoais = new DadosPessoaisModel();
            Endereco = new EnderecoModel();
        }
    }
}
