using AutoMapper;
using school_admin_api.Contracts.Database;
using school_admin_api.Contracts.DTO;
using school_admin_api.Contracts.Exceptions;
using school_admin_api.Contracts.Services;
using school_admin_api.Model;

namespace school_admin_api.Services;

public class CourseService : ICourseService
{
    private readonly ILoggerService _logger;
    private readonly ICourseDAL _courseDAL;
    private readonly IMapper _mapper;

    public CourseService(
        ILoggerService logger,
        ICourseDAL courseDAL,
        IMapper mapper)
    {
        _logger = logger;
        _courseDAL = courseDAL;
        _mapper = mapper;
    }

    public async Task<int> Create(CourseForCreationDTO courseDTO)
    {
        Course course = _mapper.Map<Course>(courseDTO);
        course.CreatedAt = DateTime.Now;
        course.UpdatedAt = DateTime.Now;
        return await _courseDAL.Create(course);
    }

    public async Task Update(int id, CourseForUpdateDTO courseDTO)
    {
        Course course = await GetRecordAndCheckExistence(id);
        _mapper.Map(courseDTO, course);
        course.UpdatedAt = DateTime.Now;
        await _courseDAL.Update(course);
    }

    public async Task Delete(int id)
    {
        Course course = await GetRecordAndCheckExistence(id);
        await _courseDAL.Delete(course);
    }

    public async Task<CourseDTO?> Retrieve(int id) =>
        _mapper.Map<CourseDTO>(await _courseDAL.Retrieve(id));

    public async Task<List<CourseDTO>> RetrieveAll() =>
        _mapper.Map<List<CourseDTO>>(await _courseDAL.RetrieveAll());

    private async Task<Course> GetRecordAndCheckExistence(int id)
    {
        Course course = await _courseDAL.Retrieve(id);
        if (course == null)
            throw new EntityNotFoundException();
        return course;
    }
}
