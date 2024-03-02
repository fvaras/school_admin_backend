using Microsoft.EntityFrameworkCore;
using school_admin_api.Contracts.Database;
using school_admin_api.Model;

namespace school_admin_api.Database;

public class AlumnoDAL : RepositoryBase<Alumno>, IAlumnoDAL
{
    private readonly ApplicationDbContext _context;

    public AlumnoDAL(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<int> Create(Alumno alumno)
    {
        await base.Create(alumno);
        return alumno.Id; // Assuming Id is auto-generated
    }

    public async Task Update(Alumno alumno) => await base.Update(alumno);

    public async Task Delete(Alumno alumno) => await base.Delete(alumno);

    public async Task<Alumno?> Retrieve(int idAlumno, bool trackChanges = false) =>
        await FindByCondition(a => a.Id == idAlumno, trackChanges)
                .FirstOrDefaultAsync(a => a.Id == idAlumno);

    public async Task<List<Alumno>> RetrieveAll() => await FindAll().ToListAsync();
}
