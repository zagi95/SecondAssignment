namespace BlazorClient.Services.Interface;

public interface IHttpService
{
    Task<T?> Get<T>(string uri);
    Task<T?> Post<T>(string uri, T data);
    Task<T?> Put<T>(string uri, T data);
    Task Delete(string uri);
}