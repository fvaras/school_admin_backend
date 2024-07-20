namespace school_admin_api.Contracts.Database.DTO;

public class TimeBlockTableRowDbDTO
{
    public Guid Id { get; set; }
    public int Year { get; set; }
    public byte Day { get; set; }
    public TimeSpan Start { get; set; }
    public TimeSpan End { get; set; }
    public bool IsRecess { get; set; }
    public Guid GradeId { get; set; }
    public string GradeName { get; set; }
}