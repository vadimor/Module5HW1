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
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return _jsonService.Deserialize<ListResponse<User>>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<SingleResponse<User>?> GetSingleUserAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return _jsonService.Deserialize<SingleResponse<User>>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<NotFoundResponse?> GetSingleUserNotFoundAsync()
        {
            var url = @$"{_siteUrl}/api/users/23";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return _jsonService.Deserialize<NotFoundResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<WorkerCreateResponse?> PostCreateAsync()
        {
            var url = @$"{_siteUrl}/api/users";
            var workerRequest = new WorkerRequest { Name = "morpheus", Job = "leader" };
            var content = new StringContent(_jsonService.Serialize(workerRequest), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, content);
            return _jsonService.Deserialize<WorkerCreateResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<WorkerUpdateResponse?> PutUpdateAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            var workerRequest = new WorkerRequest { Name = "morpheus", Job = "zion resident" };
            var content = new StringContent(_jsonService.Serialize(workerRequest), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Put, url, content);
            return _jsonService.Deserialize<WorkerUpdateResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<WorkerUpdateResponse?> PatchUpdateAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            var workerRequest = new WorkerRequest { Name = "morpheus", Job = "zion resident" };
            var content = new StringContent(_jsonService.Serialize(workerRequest), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Patch, url, content);
            return _jsonService.Deserialize<WorkerUpdateResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task DeleteAsync()
        {
            var url = @$"{_siteUrl}/api/users/2";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Delete, url);
        }

        public async Task<ListResponse<User>?> GetDelayedResponseAsync()
        {
            var url = @$"{_siteUrl}/api/users?delay=3";
            var responseMessage = await _httpService.SendAsync(HttpMethod.Get, url);
            return _jsonService.Deserialize<ListResponse<User>>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
