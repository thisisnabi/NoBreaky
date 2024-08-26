using NoBreaky.AssertionBuilders;

namespace NoBreaky.Models;

public class ParameterItem
{
    public required string Name { get; set; }
    public bool IsRequired { get; set; } = false;
    public required Type Type { get; set; }
    public ParameterType ParameterType { get; set; }
}
