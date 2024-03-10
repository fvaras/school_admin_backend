namespace school_admin_api.Contracts.DTO;

public class StudentBaseDTO
{
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte IdGender { get; set; }
    public string Address { get; set; }
    public string BloodGroup { get; set; }
    public string Allergies { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public DateTime? JoiningDate { get; set; }
    public DateTime? BirthDate { get; set; }
    public int StateId { get; set; }
}

public class StudentForCreationDTO : StudentBaseDTO
{
}

public class StudentForUpdateDTO : StudentBaseDTO
{
}

public class StudentDTO : StudentBaseDTO
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
