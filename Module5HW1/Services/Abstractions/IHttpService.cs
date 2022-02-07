namespace Module5HW1.Services.Abstractions
{
    public interface IHttpService
    {
        Task<T?> SendAsync<T>(HttpMethod httpMethod, string url, object? content = null);
    }
}
