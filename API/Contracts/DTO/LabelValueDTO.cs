namespace school_admin_api.Contracts.DTO;

public class LabelValueDTO<T>
{
    public T Value { get; set; }
    public string Label { get; set; }
}
