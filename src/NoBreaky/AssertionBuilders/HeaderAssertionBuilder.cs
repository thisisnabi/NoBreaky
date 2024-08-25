using NoBreaky.Assertions;

namespace NoBreaky.AssertionBuilders;

public class HeaderAssertionBuilder
{
    private readonly List<HeaderAssertion> _headerAssertions = [];

    public HeaderAssertionBuilder Add<TType>(string name)
    {
        _headerAssertions.Add(new HeaderAssertion
        {
            Name = name,
            Type = typeof(TType)
        });
        return this;
    }

    public HeaderAssertionBuilder IsRequired()
    {
        if (_headerAssertions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        _headerAssertions.Last().IsRequired = true;
        return this;
    }

    public IReadOnlyCollection<HeaderAssertion> Build() => _headerAssertions;
}