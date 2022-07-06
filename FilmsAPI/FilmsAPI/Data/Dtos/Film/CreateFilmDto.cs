using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos.Film
{
    public class CreateFilmDto
    {

        [Required(ErrorMessage = "O campo título é obrigatório")]
        public string Title { get; set; }
        [Required(ErrorMessage = "O campo diretor é obrigatório")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "O gênero não pode passar de 30 caracteres")]
        public string Genre { get; set; }
        [Range(1, 600, ErrorMessage = "A duração deve ter no mínimo 1 e no máximo 600 minutos")]
        public int Duration { get; set; }

    }
}
