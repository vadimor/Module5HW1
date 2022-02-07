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
            return await _httpService.SendAsync<ListResponse<Resource>>(HttpMethod.Get, url);
        }

        public async Task<SingleResponse<Resource>?> GetSingleResourceAsync()
        {
            var url = @$"{_siteUrl}/api/unknown/2";
            return await _httpService.SendAsync<SingleResponse<Resource>>(HttpMethod.Get, url);
        }

        public async Task<NotFoundResponse?> GetListResourceNotFoundAsync()
        {
            var url = @$"{_siteUrl}/api/unknown";
            return await _httpService.SendAsync<NotFoundResponse>(HttpMethod.Get, url);
        }
    }
}
