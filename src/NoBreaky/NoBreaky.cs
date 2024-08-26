using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;
using NoBreaky.AssertionBuilders;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using Xunit;
using static NoBreaky.Constants;

namespace NoBreaky;

public class NoBreaky<TProgram> where TProgram : class
{
    private readonly WebApplicationFactory<TProgram> _applicationFactory;
    private readonly string _baseOpenApiUrl = "/openapi/v1.json";
    private string _ednpoint = string.Empty;
    private IList<Action<JObject>> _functions;

    #region Constractors
    private NoBreaky(WebApplicationFactory<TProgram> applicationFactory, string baseOpenApiUrl)
    {
        _applicationFactory = applicationFactory;
        _baseOpenApiUrl = baseOpenApiUrl;
        _functions = [];
    }

    public static NoBreaky<TProgram> Create(string baseOpenApiUrl = "/openapi/v1.json")
    {
        var factory = new WebApplicationFactory<TProgram>();
        return new NoBreaky<TProgram>(factory, baseOpenApiUrl);
    }
    #endregion

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

    #region Endpoint Assersion
    public NoBreaky<TProgram> Endpoint([StringSyntax("Route")] string pattern)
    {
        _ = pattern ?? throw new ArgumentNullException(nameof(pattern));
        _ednpoint = TransformPattern(pattern);
        _functions.Add((item) =>
        {
            var path = item[JsonItems.PATHS]?[_ednpoint];
            Assert.True(path is not null, $"The path '{_ednpoint}' is missing.");
        });

        return this;
    }

    static string TransformPattern(string pattern)
    {
        string transformed = Regex.Replace(pattern, @"{[^:]+(?:[:][^}]*)?}", m =>
        {
            var itemName = Regex.Match(m.Value, @"{([^:}]+)").Groups[1].Value;
            return "{" + itemName + "}";
        });

        return transformed;
    }
    #endregion
     

    public NoBreaky<TProgram> WithHeaders(Action<HeaderAssertionBuilder> headerAssertions)
    {

        return this;
    }


    public void IsSafe()
    {
        var httpClient = _applicationFactory.CreateClient();
        var response = httpClient.GetAsync(_baseOpenApiUrl).GetAwaiter().GetResult();
        var responseAsString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        var responseAsObject = JObject.Parse(responseAsString);

        foreach (var func in _functions)
        {
            func(responseAsObject);
        }
    }
}