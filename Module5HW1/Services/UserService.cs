using Module5HW1.Models;
using Module5HW1.Models.Request;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class UserService : IUserService
    {
        private readonly IHttpService _httpService;
        private readonly IJsonService _jsonService;
        private readonly string _siteUrl;

        public UserService(IHttpService httpService, IJsonService jsonService, IConfigService configService)
        {
            _httpService = httpService;
            _jsonService = jsonService;
            _siteUrl = configService.Config.SiteUrl;
        }

        public async Task<ListResponse<User>?> GetListUsersAsync()
        {
            var url = @$"{_siteUrl}/api/users?page=2";
            return await _httpService.SendAsync<ListResponse<User>>(HttpMethod.Get, url);
        }

        public async Task<SingleResponse<User>?> GetSingleUserAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            return await _httpService.SendAsync<SingleResponse<User>>(HttpMethod.Get, url);
        }

        public async Task<NotFoundResponse?> GetSingleUserNotFoundAsync()
        {
            var url = @$"{_siteUrl}/api/users/23";
            return await _httpService.SendAsync<NotFoundResponse>(HttpMethod.Get, url);
        }

        public async Task<WorkerCreateResponse?> PostCreateAsync()
        {
            var url = @$"{_siteUrl}/api/users";
            var workerRequest = new WorkerRequest { Name = "morpheus", Job = "leader" };
            return await _httpService.SendAsync<WorkerCreateResponse>(HttpMethod.Post, url, workerRequest);
        }

        public async Task<WorkerUpdateResponse?> PutUpdateAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            var workerRequest = new WorkerRequest { Name = "morpheus", Job = "zion resident" };
            return await _httpService.SendAsync<WorkerUpdateResponse>(HttpMethod.Put, url, workerRequest);
        }

        public async Task<WorkerUpdateResponse?> PatchUpdateAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            var workerRequest = new WorkerRequest { Name = "morpheus", Job = "zion resident" };
            return await _httpService.SendAsync<WorkerUpdateResponse>(HttpMethod.Patch, url, workerRequest);
        }

        public async Task<NoContentResponse?> DeleteAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            return await _httpService.SendAsync<NoContentResponse>(HttpMethod.Delete, url);
        }

        public async Task<ListResponse<User>?> GetDelayedResponseAsync()
        {
            var url = @$"{_siteUrl}/api/users?delay=3";
            return await _httpService.SendAsync<ListResponse<User>>(HttpMethod.Get, url);
        }
    }
}
