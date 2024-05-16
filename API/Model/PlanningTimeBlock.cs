using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace school_admin_api.Model;

public class PlanningTimeBlock
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public int PlanningId { get; set; }
    public Planning Planning { get; set; }

    public int TimeBlockId { get; set; }
    public TimeBlock TimeBlock { get; set; }

    public DateTime Date { get; set; }
}
