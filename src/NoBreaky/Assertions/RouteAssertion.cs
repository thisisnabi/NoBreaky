namespace NoBreaky.Assertions;

public class RouteAssertion
{
    public required string Name { get; set; }
    public bool IsRequired { get; set; } = false;
    public required Type Type { get; set; }
}
