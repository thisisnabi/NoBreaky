using NoBreaky.Assertions;

namespace NoBreaky.AssertionBuilders;

public class FormAssertionBuilder
{
    private readonly List<FormAssertion> _formAssertions = [];

    public FormAssertionBuilder Add<TType>(string name)
    {
        _formAssertions.Add(new FormAssertion
        {
            Name = name,
            Type = typeof(TType)
        });
        return this;
    }

    public FormAssertionBuilder IsRequired()
    {
        if (_formAssertions.Count == 0)
        {
            throw new InvalidOperationException();
        }

        _formAssertions.Last().IsRequired = true;
        return this;
    }

    public IReadOnlyCollection<FormAssertion> Build() => _formAssertions;
}