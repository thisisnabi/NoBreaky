using NoBreaky.Assertions;

namespace NoBreaky.AssertionBuilders;

public class RouteAssertionBuilder
{
    private readonly List<RouteAssertion> _routeAssertions = [];

    public RouteAssertionBuilder Add<TType>(string name)
    {
        _routeAssertions.Add(new RouteAssertion
        {
            Name = name,
            Type = typeof(TType)
        });
        return this;
    }

    public RouteAssertionBuilder IsRequired()
    {
        if (_routeAssertions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        _routeAssertions.Last().IsRequired = true;
        return this;
    }

    public IReadOnlyCollection<RouteAssertion> Build() => _routeAssertions;
}