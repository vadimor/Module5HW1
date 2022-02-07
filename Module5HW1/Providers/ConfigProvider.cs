using Module5HW1.Models;
using Module5HW1.Providers.Abstractions;
using Module5HW1.Services.Abstractions;

namespace Module5HW1.Providers
{
    public class ConfigProvider : IConfigProvider
    {
        private const string ConfigPath = "./Config.json";
        private readonly IJsonService _jsonService;
        private readonly IFileService _fileService;
        public ConfigProvider(IJsonService jsonService, IFileService fileService)
        {
            _jsonService = jsonService;
            _fileService = fileService;
        }

        public Config GetConfig()
        {
            var configJson = _fileService.Read(ConfigPath);

            if (configJson is null)
            {
                throw new Exception($"Not found {ConfigPath}");
            }

            var result = _jsonService.Deserialize<Config>(configJson);

            if (result is null)
            {
                throw new Exception($"Not found class Config in {ConfigPath}");
            }

            return result;
        }
    }
}
