using AutoMapper;
using FilmsAPI.Data.Dtos.Session;
using FilmsAPI.Models;

namespace FilmsAPI.Profiles
{
    public class SessionProfile :  Profile
    {
        public SessionProfile()
        {
            CreateMap<CreateSessionDto, Session>();
            CreateMap<Session, ReadSessionDto>()
                .ForMember(dto => dto.StartTime, opts => opts
                .MapFrom(dto =>
                dto.EndTime.AddMinutes(dto.Film.Duration * (-1))));
        }

    }
}
