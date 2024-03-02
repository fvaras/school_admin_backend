using AutoMapper;
using school_admin_api.Contracts.DTO;
using school_admin_api.Model;

namespace school_admin_api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<StudentForCreationDTO, Student>();
        CreateMap<StudentForUpdateDTO, Student>();
        CreateMap<Student, StudentDTO>()
            .ForMember(p => p.StudentId, opt => opt.MapFrom(x => x.Id));

        CreateMap<CourseForCreationDTO, Course>();
        CreateMap<CourseForUpdateDTO, Course>();
        CreateMap<Course, CourseDTO>()
            .ForMember(c => c.Id, opt => opt.MapFrom(x => x.Id));

        CreateMap<TeacherForCreationDTO, Teacher>();
        CreateMap<TeacherForUpdateDTO, Teacher>();
        CreateMap<Teacher, TeacherDTO>()
            .ForMember(t => t.Id, opt => opt.MapFrom(x => x.Id));

        CreateMap<StudentGuardianForCreationDTO, StudentGuardian>();
        CreateMap<StudentGuardianForUpdateDTO, StudentGuardian>();
        CreateMap<StudentGuardian, StudentGuardianDTO>()
            .ForMember(sg => sg.Id, opt => opt.MapFrom(x => x.Id));
    }
}