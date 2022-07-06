
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace FilmsAPI.Data.Dtos.Session
{
    public class ReadSessionDto
    {
        public int Id { get; set; }

        public FilmsAPI.Models.Cinema Cinema { get; set; }
        public FilmsAPI.Models.Film Film { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}
