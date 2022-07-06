using System;

namespace FilmsAPI.Data.Dtos.Session
{
    public class CreateSessionDto
    {
        public int CinemaId { get; set; }
        public int FilmId { get; set; }
        public DateTime EndTime { get; set; }
    }
}
