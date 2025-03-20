using System.ComponentModel;
using System.Net;
using System.Text.Json;
using BlazorClient.Services.Interface;

namespace BlazorClient.Services;

public class HttpService : IHttpService
{
    private HttpClient _httpClient;

    public HttpService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public Task<T?> Get<T>(string uri)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, uri);
        
        using var response = _httpClient.SendAsync(request);
        if (response.Result.StatusCode == HttpStatusCode.Unauthorized)
        {
            return default;
        }

        return response.Result.Content.ReadFromJsonAsync<T>();
    }

    public Task<T?> Post<T>(string uri, T data)
    {
        throw new NotImplementedException();
    }

    public Task<T?> Put<T>(string uri, T data)
    {
        throw new NotImplementedException();
    }

    public Task Delete(string uri)
    {
        throw new NotImplementedException();
    }
}