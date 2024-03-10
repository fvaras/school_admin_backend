namespace school_admin_api.Contracts.Database.DTO;

public class LabelValueFromDB<T>
{
    public T Value { get; set; }
    public string Label { get; set; }
}
