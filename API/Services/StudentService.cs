using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class StudentService : IStudentService
{
    private readonly ILoggerService _logger;
    private readonly IStudentDAL _studentDAL;
    private readonly IMapper _mapper;

    public StudentService(
        ILoggerService logger,
        IStudentDAL studentDAL,
        IMapper mapper
        )
    {
        _logger = logger;
        _studentDAL = studentDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(StudentForCreationDTO studentDTO)
    {
        Student student = _mapper.Map<Student>(studentDTO);
        student.CreatedAt = DateTime.Now;
        student.UpdatedAt = DateTime.Now;
        return await _studentDAL.Create(student);
    }

    public async Task Update(int id, StudentForUpdateDTO studentDTO)
    {
        Student student = await GetRecordAndCheckExistence(id);
        _mapper.Map(studentDTO, student);
        student.UpdatedAt = DateTime.Now;
        await _studentDAL.Update(student);
    }

    public async Task Delete(int id)
    {
        Student student = await GetRecordAndCheckExistence(id);
        await _studentDAL.Delete(student);
    }

    public async Task<StudentDTO?> Retrieve(int id) => _mapper.Map<StudentDTO>(await _studentDAL.Retrieve(id));

    public async Task<List<StudentDTO>> RetrieveAll() => _mapper.Map<List<StudentDTO>>(await _studentDAL.RetrieveAll());

    private async Task<Student> GetRecordAndCheckExistence(int id)
    {
        Student student = await _studentDAL.Retrieve(id);
        if (student is null)
            throw new EntityNotFoundException();
        return student;
    }
}
