using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Data.Dtos.Address
{
    public class ReadAddressDto
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public int Number { get; set; }
    }
}
