using AutoMapper;
using DatabaseOperations.Models;
using DatabaseOperations.Models.Dto;

namespace DatabaseOperations;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap()
            .ForMember(dest=>dest.NumberDecimal, o=>o.MapFrom(z=>z.Number))
            .ForMember(dest => dest.NumberDouble, o => o.MapFrom(z => z.Number))
            .ForMember(dest => dest.NumberFloat, o => o.MapFrom(z => z.Number));

        CreateMap<Department, DepartmentDto>().ReverseMap()
            .ForMember(dest => dest.NumberInt, o => o.MapFrom(z => z.Number))
            .ForMember(dest => dest.NumberLong, o => o.MapFrom(z => z.Number))
            .ForMember(dest => dest.NumberFloat, o => o.MapFrom(z => z.Number))
            .ForMember(dest => dest.NumberDouble, o => o.MapFrom(z => z.Number))
            .ForMember(dest => dest.NumberDecimal, o => o.MapFrom(z => z.Number))
            ;
    }
}