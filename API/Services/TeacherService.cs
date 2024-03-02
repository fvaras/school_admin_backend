using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class TeacherService : ITeacherService
{
    private readonly ILoggerService _logger;
    private readonly ITeacherDAL _teacherDAL;
    private readonly IMapper _mapper;

    public TeacherService(
        ILoggerService logger,
        ITeacherDAL teacherDAL,
        IMapper mapper)
    {
        _logger = logger;
        _teacherDAL = teacherDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(TeacherForCreationDTO teacherDTO)
    {
        Teacher teacher = _mapper.Map<Teacher>(teacherDTO);
        teacher.CreatedAt = DateTime.Now;
        teacher.UpdatedAt = DateTime.Now;
        return await _teacherDAL.Create(teacher);
    }

    public async Task Update(int id, TeacherForUpdateDTO teacherDTO)
    {
        Teacher teacher = await GetRecordAndCheckExistence(id);
        _mapper.Map(teacherDTO, teacher);
        teacher.UpdatedAt = DateTime.Now;
        await _teacherDAL.Update(teacher);
    }

    public async Task Delete(int id)
    {
        Teacher teacher = await GetRecordAndCheckExistence(id);
        await _teacherDAL.Delete(teacher);
    }

    public async Task<TeacherDTO?> Retrieve(int id) =>
        _mapper.Map<TeacherDTO>(await _teacherDAL.Retrieve(id));

    public async Task<List<TeacherDTO>> RetrieveAll() =>
        _mapper.Map<List<TeacherDTO>>(await _teacherDAL.RetrieveAll());

    private async Task<Teacher> GetRecordAndCheckExistence(int id)
    {
        Teacher teacher = await _teacherDAL.Retrieve(id);
        if (teacher == null)
            throw new EntityNotFoundException();
        return teacher;
    }
}
