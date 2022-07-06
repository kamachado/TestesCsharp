using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos.Cinema
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }

    }
}
