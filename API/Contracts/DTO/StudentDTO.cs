namespace school_admin_api.Contracts.DTO;

public class StudentBaseDTO
{
    public string BloodGroup { get; set; }
    public string Allergies { get; set; }
    public DateTime? JoiningDate { get; set; }
}

public class StudentForCreationDTO : StudentBaseDTO
{
    public UserForCreationDTO User { get; set; }
}

public class StudentForUpdateDTO : StudentBaseDTO
{
}

public class StudentDTO : StudentBaseDTO
{
    public byte StateId { get; set; }
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public UserDTO User { get; set; }
}
