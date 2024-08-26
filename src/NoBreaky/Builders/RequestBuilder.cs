using NoBreaky.Models;

namespace NoBreaky.Builders;

public class RequestBuilder
{
    private readonly List<ParameterItem> _items;

    public RequestBuilder()
    {
       _items = [];
    }

    public RequestBuilder RequestWith(Action<RequestBuilder> request)
    {
        var builder = new RequestBuilder();
        request(builder);
        return this;
    }

    public RequestBuilder WithHeaders(Action<RequestItemBuilder> configureAction)
    {
        var builder = new RequestItemBuilder(ParameterType.Header);
        configureAction(builder);
        _items.AddRange(builder.Build());
        return this;
    }

    public RequestBuilder WithRoutes(Action<RequestItemBuilder> configureAction)
    {
        var builder = new RequestItemBuilder(ParameterType.Route);
        configureAction(builder);
        _items.AddRange(builder.Build());
        return this;
    }

    public RequestBuilder WithForm(Action<RequestItemBuilder> configureAction)
    {
        var builder = new RequestItemBuilder(ParameterType.Form);
        configureAction(builder);
        _items.AddRange(builder.Build());
        return this;
    }

    public RequestBuilder WithQueryString(Action<RequestItemBuilder> configureAction)
    {
        var builder = new RequestItemBuilder(ParameterType.QueryString);
        configureAction(builder);
        _items.AddRange(builder.Build());
        return this;
    }


    public RequestBuilder WithBody<TBodyModel>()
    {

        return this;
    }


    public IReadOnlyCollection<ParameterItem> Build() => _items;
}

