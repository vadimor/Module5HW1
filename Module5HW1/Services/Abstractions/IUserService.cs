using Module5HW1.Models;
using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstractions
{
    public interface IUserService
    {
        Task DeleteAsync();
        Task<ListResponse<User>?> GetDelayedResponseAsync();
        Task<ListResponse<User>?> GetListUsersAsync();
        Task<SingleResponse<User>?> GetSingleUserAsync();
        Task<NotFoundResponse?> GetSingleUserNotFoundAsync();
        Task<WorkerUpdateResponse?> PatchUpdateAsync();
        Task<WorkerCreateResponse?> PostCreateAsync();
        Task<WorkerUpdateResponse?> PutUpdateAsync();
    }
}