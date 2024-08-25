namespace NoBreaky.Assertions;

public class FormAssertion
{
    public required string Name { get; set; }
    public bool IsRequired { get; set; } = false;
    public required Type Type { get; set; }
}
