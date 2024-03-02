using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("Alumnos", Schema = "public")]
public class Alumno
{
    [Column("IdAlumno")]
    public int Id { get; set; }
    public string Rut { get; set; }
    public string Nombre { get; set; }
    public int? IdCurso { get; set; }
    public int IdEstado { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
