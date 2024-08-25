using Microsoft.AspNetCore.Mvc.Testing;
using NoBreaky.AssertionBuilders;

namespace NoBreaky;

public class NoBreaky<TProgram> where TProgram : class
{
    private readonly WebApplicationFactory<TProgram> _applicationFactory;
    private readonly string _baseOpenApiUrl = "/openapi/v1.json";

    private NoBreaky(WebApplicationFactory<TProgram> applicationFactory, string baseOpenApiUrl)
    {
        _applicationFactory = applicationFactory;
        _baseOpenApiUrl = baseOpenApiUrl;
    }

    public static NoBreaky<TProgram> Create(string baseOpenApiUrl = "/openapi/v1.json")
    {
        var factory = new WebApplicationFactory<TProgram>();
        return new NoBreaky<TProgram>(factory, baseOpenApiUrl);
    }

    public NoBreaky<TProgram> WithHeaders(Action<HeaderAssertionBuilder> headerAssertions)
    {
        var builder = new HeaderAssertionBuilder();
        headerAssertions(builder);
        // _headerAssertions = builder.Build();
        return this;
    }

}