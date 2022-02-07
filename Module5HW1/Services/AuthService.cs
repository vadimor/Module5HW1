﻿using Module5HW1.Models.Request;
using Module5HW1.Models.Response;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpService _httpService;
        private readonly IJsonService _jsonService;
        private readonly string _siteUrl;

        public AuthService(IHttpService httpService, IJsonService jsonService, IConfigService configService)
        {
            _httpService = httpService;
            _jsonService = jsonService;
            _siteUrl = configService.Config.SiteUrl;
        }

        public async Task<AuthorizationResponse?> PostRegisterSuccessfulAsync()
        {
            var url = @$"{_siteUrl}/api/register";
            var authorizationRequest = new AuthorizationRequest { Email = @"eve.holt@reqres.in", Password = "pistol" };
            var content = new StringContent(_jsonService.Serialize(authorizationRequest), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, content);
            return _jsonService.Deserialize<AuthorizationResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<BadRequestResponse?> PostRegisterUnsuccessfulAsync()
        {
            var url = @$"{_siteUrl}/api/register";
            var authorizationRequest = new AuthorizationRequest { Email = @"sydney@fife" };
            var content = new StringContent(_jsonService.Serialize(authorizationRequest), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, content);
            return _jsonService.Deserialize<BadRequestResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<AuthorizationResponse?> PostLoginSuccessfulAsync()
        {
            var url = @$"{_siteUrl}/api/login";
            var authorizationRequest = new AuthorizationRequest { Email = @"eve.holt@reqres.in", Password = "cityslicka" };
            var content = new StringContent(_jsonService.Serialize(authorizationRequest), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, content);
            return _jsonService.Deserialize<AuthorizationResponse>(await responseMessage.Content.ReadAsStringAsync());
        }

        public async Task<NotFoundResponse?> PostLoginUnsuccessfulAsync()
        {
            var url = @$"{_siteUrl}/api/login";
            var authorizationRequest = new AuthorizationRequest { Email = @"peter@klaven" };
            var content = new StringContent(_jsonService.Serialize(authorizationRequest), System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await _httpService.SendAsync(HttpMethod.Post, url, content);
            return _jsonService.Deserialize<NotFoundResponse>(await responseMessage.Content.ReadAsStringAsync());
        }
    }
}
