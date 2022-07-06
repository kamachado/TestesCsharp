using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FilmsAPI.Models
{
    public class Film
    {
        [Key]
        [Required]
        public int Id { get;  set; }

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genre { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duration { get; set; }

        public int Classification { get; set; }
        [JsonIgnore]
        public virtual List<Session> Session { get; set; }

    }
}
