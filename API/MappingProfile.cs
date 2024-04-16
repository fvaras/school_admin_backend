using AutoMapper;
using school_admin_api.Contracts.Database.DTO;
using school_admin_api.Contracts.DTO;
using school_admin_api.Model;

namespace school_admin_api;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {
        CreateMap<UserForCreationDTO, User>();
        CreateMap<UserForUpdateDTO, User>();
        CreateMap<User, UserDTO>();
        CreateMap<User, UserInfoDTO>();

        CreateMap<StudentForCreationDTO, Student>();
        CreateMap<StudentForUpdateDTO, Student>();
        CreateMap<Student, StudentDTO>();
        CreateMap<Student, StudentTableRowDTO>()
            .ForPath(t => t.Id, opt => opt.MapFrom(x => x.Id))
            .ForPath(t => t.UserName, opt => opt.MapFrom(x => x.User.UserName))
            .ForPath(t => t.UserId, opt => opt.MapFrom(x => x.User.Id))
            .ForPath(t => t.Rut, opt => opt.MapFrom(x => x.User.Rut))
            .ForPath(t => t.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForPath(t => t.LastName, opt => opt.MapFrom(x => x.User.LastName))
            .ForPath(t => t.Email, opt => opt.MapFrom(x => x.User.Email))
            .ForPath(t => t.Phone, opt => opt.MapFrom(x => x.User.Phone))
            .ForPath(t => t.Address, opt => opt.MapFrom(x => x.User.Address))
            .ForPath(t => t.Gender, opt => opt.MapFrom(x => x.User.Gender))
            .ForPath(t => t.BirthDate, opt => opt.MapFrom(x => x.User.BirthDate))
            .ForPath(t => t.BloodGroup, opt => opt.MapFrom(x => x.BloodGroup))
            .ForPath(t => t.Allergies, opt => opt.MapFrom(x => x.Allergies))
            .ForPath(t => t.JoiningDate, opt => opt.MapFrom(x => x.JoiningDate))
            .ForPath(t => t.StateId, opt => opt.MapFrom(x => x.StateId))
            .ForPath(t => t.GradeName, opt => opt.MapFrom(x => x.Grade.Name));

        CreateMap<GradeForCreationDTO, Grade>();
        CreateMap<GradeForUpdateDTO, Grade>();
        CreateMap<Grade, GradeDTO>()
            .ForMember(c => c.Id, opt => opt.MapFrom(x => x.Id));

        CreateMap<TeacherForCreationDTO, Teacher>();
        CreateMap<TeacherForUpdateDTO, Teacher>();
        CreateMap<Teacher, TeacherDTO>()
            .ForMember(t => t.Id, opt => opt.MapFrom(x => x.Id));
        CreateMap<Teacher, TeacherTableRowDTO>()
            .ForPath(t => t.Id, opt => opt.MapFrom(x => x.Id))
            .ForPath(t => t.UserName, opt => opt.MapFrom(x => x.User.UserName))
            .ForPath(t => t.UserId, opt => opt.MapFrom(x => x.User.Id))
            .ForPath(t => t.Rut, opt => opt.MapFrom(x => x.User.Rut))
            .ForPath(t => t.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForPath(t => t.LastName, opt => opt.MapFrom(x => x.User.LastName))
            .ForPath(t => t.Email, opt => opt.MapFrom(x => x.User.Email))
            .ForPath(t => t.Phone, opt => opt.MapFrom(x => x.User.Phone))
            .ForPath(t => t.Address, opt => opt.MapFrom(x => x.User.Address))
            .ForPath(t => t.Gender, opt => opt.MapFrom(x => x.User.Gender))
            .ForPath(t => t.ContactEmail, opt => opt.MapFrom(x => x.ContactEmail))
            .ForPath(t => t.ContactPhone, opt => opt.MapFrom(x => x.ContactPhone))
            .ForPath(t => t.BirthDate, opt => opt.MapFrom(x => x.User.BirthDate))
            .ForPath(t => t.Education, opt => opt.MapFrom(x => x.Education))
            .ForPath(t => t.StateId, opt => opt.MapFrom(x => x.StateId))
            ;

        CreateMap<StudentGuardianForCreationDTO, StudentGuardian>();
        CreateMap<StudentGuardianForUpdateDTO, StudentGuardian>();
        CreateMap<StudentGuardian, StudentGuardianDTO>()
            .ForMember(sg => sg.Id, opt => opt.MapFrom(x => x.Id));
        CreateMap<StudentGuardian, StudentGuardianTableRowDTO>()
            .ForPath(t => t.Id, opt => opt.MapFrom(x => x.Id))
            .ForPath(t => t.UserName, opt => opt.MapFrom(x => x.User.UserName))
            .ForPath(t => t.UserId, opt => opt.MapFrom(x => x.User.Id))
            .ForPath(t => t.Rut, opt => opt.MapFrom(x => x.User.Rut))
            .ForPath(t => t.FirstName, opt => opt.MapFrom(x => x.User.FirstName))
            .ForPath(t => t.LastName, opt => opt.MapFrom(x => x.User.LastName))
            .ForPath(t => t.Email, opt => opt.MapFrom(x => x.User.Email))
            .ForPath(t => t.Phone, opt => opt.MapFrom(x => x.User.Phone))
            .ForPath(t => t.Address, opt => opt.MapFrom(x => x.User.Address))
            // .ForPath(t => t.Gender, opt => opt.MapFrom(x => x.User.Gender))
            .ForPath(t => t.BirthDate, opt => opt.MapFrom(x => x.User.BirthDate))
            .ForPath(t => t.StateId, opt => opt.MapFrom(x => x.StateId));

        CreateMap(typeof(LabelValueFromDB<>), typeof(LabelValueDTO<>));

        CreateMap<CalendarForCreationDTO, Calendar>();
        CreateMap<CalendarForUpdateDTO, Calendar>();
        CreateMap<Calendar, CalendarDTO>();

        CreateMap<CalendarEventForCreationDTO, CalendarEvent>()
            .ForMember(entity => entity.EventType, opt => opt.MapFrom(x => x.Type))
            .ForMember(entity => entity.StartDate, opt => opt.MapFrom(x => ISODt2DateTime(x.StartISODate)))
            .ForMember(entity => entity.EndDate, opt => opt.MapFrom(x => ISODt2DateTime(x.EndISODate)));
        CreateMap<CalendarEventForUpdateDTO, CalendarEvent>()
            .ForMember(entity => entity.EventType, opt => opt.MapFrom(x => x.Type))
            .ForMember(entity => entity.StartDate, opt => opt.MapFrom(x => ISODt2DateTime(x.StartISODate)))
            .ForMember(entity => entity.EndDate, opt => opt.MapFrom(x => ISODt2DateTime(x.EndISODate)));
        CreateMap<CalendarEvent, CalendarEventDTO>()
            .ForMember(dto => dto.Type, opt => opt.MapFrom(x => x.EventType));
    }

    private DateTime ISODt2DateTime(string ISODateTime)
    {
        return DateTime.ParseExact(ISODateTime, "yyyyMMddHHmmss", null);
    }
}