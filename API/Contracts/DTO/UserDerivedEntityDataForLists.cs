namespace school_admin_api.Contracts.DTO;

public class UserDerivedEntityDataForLists<T>
{
    public T Id { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
