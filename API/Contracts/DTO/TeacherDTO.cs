namespace school_admin_api.Contracts.DTO;

public class TeacherBaseDTO
{
    public string ContactEmail { get; set; }
    public string ContactPhone { get; set; }
    public string Education { get; set; }
}

public class TeacherForCreationDTO : TeacherBaseDTO
{
    public UserForCreationDTO User { get; set; }
}

public class TeacherForUpdateDTO : TeacherBaseDTO
{
    // public UserForUpdateDTO User { get; set; }
    public byte IdState { get; set; }
}

public class TeacherDTO : TeacherBaseDTO
{
    public int Id { get; init; }
    public byte StateId { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime? UpdatedAt { get; init; }
    public UserDTO User { get; set; }    
}
