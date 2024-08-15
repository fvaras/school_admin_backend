namespace school_admin_api.Contracts.DTO;

public class LabelValueDTO<T>
{
    public T Value { get; set; }
    public string Label { get; set; }
}

public class PKFKPair<TPK, TFK>
{
    public LabelValueDTO<TPK> LabelValuePK { get; set; }
    public LabelValueDTO<TFK> LabelValueFK { get; set; }
}
