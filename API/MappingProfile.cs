using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Model;

namespace school_admin_api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MyEntityForCreationDTO, MyEntity>();
        CreateMap<MyEntityForUpdateDTO, MyEntity>();
        CreateMap<MyEntity, MyEntityDTO>()
            .ForMember(p => p.IdMyEntity, opt => opt.MapFrom(x => x.Id));
    }
}