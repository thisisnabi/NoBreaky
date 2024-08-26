using NoBreaky.Models;

namespace NoBreaky.AssertionBuilders;

public class ResponseBuilder
{
    private readonly List<ParameterItem> _items;

    public ResponseBuilder()
    {
       _items = [];
    }

    public ResponseBuilder ResponseOn<TModel>(Action<ResponseBuilder> request)
    {
        var builder = new ResponseBuilder();
        request(builder);
        return this;
    }
      
    public IReadOnlyCollection<ParameterItem> Build() => _items;
}

