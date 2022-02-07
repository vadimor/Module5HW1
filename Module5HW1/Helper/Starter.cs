using Module5HW1.Services.Abstractions;

namespace Module5HW1.Helper
{
    public class Starter
    {
        private readonly IUserService _userService;
        private readonly IResourceService _resourceService;
        private readonly IAuthService _authService;

        public Starter(IUserService userService, IResourceService resourceService, IAuthService authService)
        {
            _userService = userService;
            _resourceService = resourceService;
            _authService = authService;
        }

        public void Run()
        {
            List<Task> tasks = new List<Task>();
            tasks.Add(_userService.GetListUsersAsync());
            tasks.Add(_userService.GetSingleUserAsync());
            tasks.Add(_userService.GetSingleUserNotFoundAsync());
            tasks.Add(_userService.PostCreateAsync());
            tasks.Add(_userService.PutUpdateAsync());
            tasks.Add(_userService.PatchUpdateAsync());
            tasks.Add(_userService.DeleteAsync());
            tasks.Add(_userService.GetDelayedResponseAsync());
            tasks.Add(_resourceService.GetListResourceAsync());
            tasks.Add(_resourceService.GetSingleResourceAsync());
            tasks.Add(_resourceService.GetListResourceNotFoundAsync());
            tasks.Add(_authService.PostRegisterSuccessfulAsync());
            tasks.Add(_authService.PostRegisterUnsuccessfulAsync());
            tasks.Add(_authService.PostLoginSuccessfulAsync());
            tasks.Add(_authService.PostLoginUnsuccessfulAsync());
            Task.WaitAll(tasks.ToArray());
        }
    }
}
