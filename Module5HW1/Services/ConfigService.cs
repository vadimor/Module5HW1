using Module5HW1.Models;
using Module5HW1.Providers.Abstractions;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class ConfigService : IConfigService
    {
        private readonly IConfigProvider _configProvider;
        public ConfigService(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
            Config = _configProvider.GetConfig();
        }

        public Config Config { get; init; }
    }
}
