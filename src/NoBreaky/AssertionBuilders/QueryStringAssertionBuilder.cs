using NoBreaky.Assertions;

namespace NoBreaky.AssertionBuilders;

public class QueryStringAssertionBuilder
{
    private readonly List<QueryStringAssertion> _queryStringAssertions = [];

    public QueryStringAssertionBuilder Add<TType>(string name)
    {
        _queryStringAssertions.Add(new QueryStringAssertion
        {
            Name = name,
            Type = typeof(TType)
        });
        return this;
    }

    public QueryStringAssertionBuilder IsRequired()
    {
        if (_queryStringAssertions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        _queryStringAssertions.Last().IsRequired = true;
        return this;
    }

    public IReadOnlyCollection<QueryStringAssertion> Build() => _queryStringAssertions;
}