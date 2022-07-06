using AutoMapper;
using FilmsAPI.Data.Dtos.Film;
using FilmsAPI.Models;

namespace FilmsAPI.Profiles
{
    public class FilmProfilecs : Profile
    {
        public FilmProfilecs()
        {
            CreateMap<CreateFilmDto, Film>();
            CreateMap<UpdateFilmDto, Film>();

        }


    }
}
