namespace BlazorClient.Services.Interface;

public interface IHttpService
{
    Task<T?> Get<T>(string uri);
    Task<T?> Post<T>(string uri, T data);
    Task<TResp?> Post<TReq, TResp>(string uri, TReq data, Dictionary<string, string>? headers = null);
    Task<T?> Put<T>(string uri, T data);
    Task<bool> Delete(string uri);
}