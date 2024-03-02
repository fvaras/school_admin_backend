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

        CreateMap<AlumnoForCreationDTO, Alumno>();
        CreateMap<AlumnoForUpdateDTO, Alumno>();
        CreateMap<Alumno, AlumnoDTO>()
            .ForMember(p => p.IdAlumno, opt => opt.MapFrom(x => x.Id));
    }
}