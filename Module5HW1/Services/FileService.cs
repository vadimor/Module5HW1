using Module5HW1.Services.Abstractions;

namespace Module5HW1.Services
{
    public class FileService : IFileService
    {
        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
