using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;
        private readonly IJsonService _jsonService;

        public HttpService(IJsonService jsonService)
        {
            _httpClient = new HttpClient();
            _jsonService = jsonService;
        }

        public async Task<T?> SendAsync<T>(HttpMethod httpMethod, string url, object? content = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            if (content is not null)
            {
                var httpContent = new StringContent(
                 _jsonService.Serialize(content), System.Text.Encoding.UTF8, "application/json");
                request.Content = httpContent;
            }

            var response = await _httpClient.SendAsync(request);
            var jsonContent = await response.Content.ReadAsStringAsync();
            return _jsonService.Deserialize<T>(jsonContent);
        }
    }
}
