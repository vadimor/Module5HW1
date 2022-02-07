using Microsoft.Extensions.DependencyInjection;
using Module5HW1.Providers;
using Module5HW1.Providers.Abstractions;
using Module5HW1.Services;
using Module5HW1.Services.Abstractions;
using Module5HW1.Helper;

namespace Module5HW1
{
    public class Program
    {
        public static void Main()
        {
            var ioc = new ServiceCollection()
                .AddTransient<IConfigProvider, ConfigProvider>()
                .AddSingleton<IConfigService, ConfigService>()
                .AddSingleton<IFileService, FileService>()
                .AddSingleton<IJsonService, JsonService>()
                .AddSingleton<IHttpService, HttpService>()
                .AddTransient<IUserService, UserService>()
                .AddTransient<IAuthService, AuthService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<IResourceService, ResourceService>()
                .AddTransient<Starter>()
                .BuildServiceProvider();
            var start = ioc.GetService<Starter>();

            if (start is null)
            {
                return;
            }

            start.Run();
            Console.Read();
        }
    }
}