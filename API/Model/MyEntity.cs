using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

[Table("MyEntities", Schema = "public")]
public class MyEntity
{
    [Column("IdMyEntity")]
    public int Id { get; set; }
    public string Rut { get; set; }
    public short Codigo { get; set; }
    public string Cuenta { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}