using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Api.Models
{
    public class EmailModel
    {
        [Required]
        [MaxLength(100)]
        [DataMember(Name="email")]
        public string Email { get; set; }
    }
}