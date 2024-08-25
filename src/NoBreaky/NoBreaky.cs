using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using NoBreaky.AssertionBuilders;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.CodeAnalysis;

namespace NoBreaky;

public class NoBreaky<TProgram> where TProgram : class
{
    private readonly WebApplicationFactory<TProgram> _applicationFactory;
    private readonly string _baseOpenApiUrl = "/openapi/v1.json";
    private string _pattern = string.Empty;

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

    #region Http Verbs
    public NoBreaky<TProgram> IsGetMethod() => Method(Constants.HttpMethod.GET);

    public NoBreaky<TProgram> IsDeleteMethod() => Method(Constants.HttpMethod.DELETE);

    public NoBreaky<TProgram> IsPostMethod() => Method(Constants.HttpMethod.POST);

    public NoBreaky<TProgram> IsPatchMethod() => Method(Constants.HttpMethod.PATCH);

    public NoBreaky<TProgram> IsPutMethod() => Method(Constants.HttpMethod.PUT);

    public NoBreaky<TProgram> IsHeadMethod() => Method(Constants.HttpMethod.HEAD);

    public NoBreaky<TProgram> IsConnectMethod() => Method(Constants.HttpMethod.CONNECT);

    public NoBreaky<TProgram> IsOptionsMethod() => Method(Constants.HttpMethod.OPTIONS);

    public NoBreaky<TProgram> IsTraceMethod() => Method(Constants.HttpMethod.TRACE);

    public NoBreaky<TProgram> Method(string method)
    { 
        return this;
    }
    #endregion
     
    public NoBreaky<TProgram> WithHeaders(Action<HeaderAssertionBuilder> headerAssertions)
    {
        var builder = new HeaderAssertionBuilder();
        headerAssertions(builder);
        // _headerAssertions = builder.Build();
        return this;
    }
     
    public NoBreaky<TProgram> Endpoint([StringSyntax("Route")] string pattern)
    {
  
        return this;
    }

    public void IsSafe()
    {

    }
}