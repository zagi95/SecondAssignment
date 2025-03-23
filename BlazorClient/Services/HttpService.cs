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
            return null;
        }

        return response.Result.Content.ReadFromJsonAsync<T>();
    }

    public async Task<T?> Post<T>(string uri, T data)
    {
        var response = await _httpClient.PostAsJsonAsync(uri, data);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }

        return default;
    }

    public async Task<TResp?> Post<TReq, TResp>(string uri, TReq data, Dictionary<string, string>? headers = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, uri)
        {
            Content = JsonContent.Create(data)
        };
        if (headers != null)
        {
            foreach (var header in headers)
            {
                request.Headers.TryAddWithoutValidation(header.Key, header.Value);
            }
        }
        Console.WriteLine("HEADER USER AGENT: " + request.Headers.UserAgent.ToString());
        var response = await _httpClient.SendAsync(request);
        
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<TResp>();
        }
        
        return default;
    }

    public async Task<T?> Put<T>(string uri, T data)
    {
        var response = await _httpClient.PutAsJsonAsync(uri, data);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<T>();
        }

        return default;
    }

    public async Task<bool> Delete(string uri)
    {
        var response = await _httpClient.DeleteAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            return true;
        }
        return false; 
    }
}