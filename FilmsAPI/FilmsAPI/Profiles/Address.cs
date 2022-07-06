using AutoMapper;
using FilmsAPI.Data.Dtos.Address;
using FilmsAPI.Models;

namespace FilmsAPI.Profiles
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<CreateAddressDto, Address>();
            CreateMap<Address, ReadAddressDto >();
            CreateMap<UpdateAddressDto, Address>();
        }
    }
}
