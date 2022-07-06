using AutoMapper;
using FilmsAPI.Data.Dtos.Manager;
using FilmsAPI.Models;
using System.Linq;

namespace FilmsAPI.Profiles
{
    public class ManagerProfile : Profile
    {
        public ManagerProfile()
        {
            CreateMap<CreateManagerDto, Manager>();
            CreateMap<Manager, ReadManagerDto>()
                .ForMember(manager => manager.Cinemas, opts => opts
                .MapFrom(manager => manager.Cinemas.Select
                (c => new { c.Id, c.Name, c.Address, c.AddressId })));

        }
    }
}
