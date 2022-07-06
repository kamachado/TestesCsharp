using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos.Cinema
{
    public class CreateCinemaDto  
    {
        [Required(ErrorMessage = "O campo de nome é obrigatório")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ManagerId { get; set; }
    }
}
