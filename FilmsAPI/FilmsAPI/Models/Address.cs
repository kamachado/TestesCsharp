using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmsAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Street { get; set; }
        public string District { get; set; }
        public int Number { get; set; }

        [JsonIgnore]
        public virtual  Cinema Cinema { get; set; }
    }
}
