using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstractions
{
    public interface IAuthService
    {
        Task<AuthorizationResponse?> PostLoginSuccessfulAsync();
        Task<NotFoundResponse?> PostLoginUnsuccessfulAsync();
        Task<AuthorizationResponse?> PostRegisterSuccessfulAsync();
        Task<BadRequestResponse?> PostRegisterUnsuccessfulAsync();
    }
}