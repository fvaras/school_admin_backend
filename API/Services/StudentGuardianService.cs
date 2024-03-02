using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class StudentGuardianService : IStudentGuardianService
{
    private readonly ILoggerService _logger;
    private readonly IStudentGuardianDAL _studentGuardianDAL;
    private readonly IMapper _mapper;

    public StudentGuardianService(
        ILoggerService logger,
        IStudentGuardianDAL studentGuardianDAL,
        IMapper mapper)
    {
        _logger = logger;
        _studentGuardianDAL = studentGuardianDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(StudentGuardianForCreationDTO studentGuardianDTO)
    {
        StudentGuardian studentGuardian = _mapper.Map<StudentGuardian>(studentGuardianDTO);
        studentGuardian.CreatedAt = DateTime.Now;
        studentGuardian.UpdatedAt = DateTime.Now;
        return await _studentGuardianDAL.Create(studentGuardian);
    }

    public async Task Update(int id, StudentGuardianForUpdateDTO studentGuardianDTO)
    {
        StudentGuardian studentGuardian = await GetRecordAndCheckExistence(id);
        _mapper.Map(studentGuardianDTO, studentGuardian);
        studentGuardian.UpdatedAt = DateTime.Now;
        await _studentGuardianDAL.Update(studentGuardian);
    }

    public async Task Delete(int id)
    {
        StudentGuardian studentGuardian = await GetRecordAndCheckExistence(id);
        await _studentGuardianDAL.Delete(studentGuardian);
    }

    public async Task<StudentGuardianDTO?> Retrieve(int id) =>
        _mapper.Map<StudentGuardianDTO>(await _studentGuardianDAL.Retrieve(id));

    public async Task<List<StudentGuardianDTO>> RetrieveAll() =>
        _mapper.Map<List<StudentGuardianDTO>>(await _studentGuardianDAL.RetrieveAll());

    private async Task<StudentGuardian> GetRecordAndCheckExistence(int id)
    {
        StudentGuardian studentGuardian = await _studentGuardianDAL.Retrieve(id);
        if (studentGuardian == null)
            throw new EntityNotFoundException();
        return studentGuardian;
    }
}
