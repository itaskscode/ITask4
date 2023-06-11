using AutoMapper;
using Task4.Domain.Entities;
using Task4.Service.DTOs;

namespace Task4.Service.Mappers;

public class MapperProfile : Profile
{
    public MapperProfile() 
    {
        CreateMap<User, UserCreationDto>().ReverseMap();
        CreateMap<User, UserResultDto>().ReverseMap();
    }
}