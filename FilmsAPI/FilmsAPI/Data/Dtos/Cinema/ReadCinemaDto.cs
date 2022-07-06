using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos.Cinema
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }
        public FilmsAPI.Models.Address address { get; set; }

        public FilmsAPI.Models.Manager Manager { get; set; }



    }
}
