using Module5HW1.Models;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IHttpService _httpService;
        private readonly IJsonService _jsonService;
        private readonly string _siteUrl;

        public ResourceService(IHttpService httpService, IJsonService jsonService, IConfigService configService)
        {
            _httpService = httpService;
            _jsonService = jsonService;
            _siteUrl = configService.Config.SiteUrl;
        }

        public async Task<ListResponse<Resource>?> GetListResourceAsync()
        {
            var url = @$"{_siteUrl}/api/unknown";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return _jsonService.Deserialize<ListResponse<Resource>>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<SingleResponse<Resource>?> GetSingleResourceAsync()
        {
            var url = @$"{_siteUrl}/api/unknown/2";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return _jsonService.Deserialize<SingleResponse<Resource>>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<NotFoundResponse?> GetListResourceNotFoundAsync()
        {
            var url = @$"{_siteUrl}/api/unknown";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return _jsonService.Deserialize<NotFoundResponse>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
