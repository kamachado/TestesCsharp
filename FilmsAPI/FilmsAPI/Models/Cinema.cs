using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmsAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        public string Name { get; set; }

        public virtual  Address Address { get; set; } 

        public int AddressId { get; set; }
        public virtual Manager  Manager { get; set; }
        public int ManagerId { get; set; }
        [JsonIgnore]
        public virtual List<Session> Session { get; set; }
    }
}
