using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

public class PlanningTimeBlock
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public Guid PlanningId { get; set; }
    public Planning Planning { get; set; }

    public Guid TimeBlockId { get; set; }
    public TimeBlock TimeBlock { get; set; }

    public DateTimeOffset Date { get; set; }
}
