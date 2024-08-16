namespace school_admin_api.Contracts.Repository.DTO;

public class UserDerivedEntityDbDataForLists<T>
{
    public T Id { get; set; }
    public string Rut { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
