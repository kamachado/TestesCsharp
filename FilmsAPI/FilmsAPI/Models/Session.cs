using System;
using System.ComponentModel.DataAnnotations;

namespace FilmsAPI.Models
{
    public class Session
    {

        [Key]
        [Required]
        public int Id { get; set; }
        public virtual Cinema Cinema { get; set; }
        public virtual Film Film { get; set; }
        public int FilmId { get; set; }
        public int CinemaId { get; set; }
        public DateTime EndTime { get; set; }
    }
}
