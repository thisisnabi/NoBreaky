using NoBreaky.Models;

namespace NoBreaky.Builders;

public class RequestItemBuilder
{
    private readonly ParameterType _type;
    private readonly List<ParameterItem> _headerAssertions;

    public RequestItemBuilder(ParameterType type)
    {
        _headerAssertions = [];
        _type = type;
    }

    public RequestItemBuilder Add<T>(string name)
    {
        var headerAssertion = new ParameterItem
        {
            Name = name,
            Type = typeof(T),
            ParameterType = _type
        };
        _headerAssertions.Add(headerAssertion);
        return this;
    }

    public RequestItemBuilder IsRequired()
    {
        if (_headerAssertions.Any())
        {
            _headerAssertions.Last().IsRequired = true;
        }
        return this;
    }

    public IReadOnlyCollection<ParameterItem> Build() => _headerAssertions;
}