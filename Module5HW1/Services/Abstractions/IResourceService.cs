using Module5HW1.Models;
using Module5HW1.Models.Response;

namespace Module5HW1.Services.Abstractions
{
    public interface IResourceService
    {
        Task<ListResponse<Resource>?> GetListResourceAsync();
        Task<NotFoundResponse?> GetListResourceNotFoundAsync();
        Task<SingleResponse<Resource>?> GetSingleResourceAsync();
    }
}