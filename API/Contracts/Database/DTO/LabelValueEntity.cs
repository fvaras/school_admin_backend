namespace school_admin_api.Contracts.Database.DTO;

public class LabelValueFromDB<T>
{
    public T Value { get; set; }
    public string Label { get; set; }
}

public class PKFKFromDBPair<TPK, TFK>
{
    public LabelValueFromDB<TPK> LabelValuePK { get; set; }
    public LabelValueFromDB<TFK> LabelValueFK { get; set; }
}