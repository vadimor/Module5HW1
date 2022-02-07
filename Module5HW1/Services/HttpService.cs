using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient _httpClient;

        public HttpService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string url, HttpContent? content = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);
            request.Content = content;
            var response = await _httpClient.SendAsync(request);
            return response;
        }
    }
}
