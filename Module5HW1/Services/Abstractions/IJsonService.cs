namespace Module5HW1.Services.Abstractions
{
    public interface IJsonService
    {
        public T? Deserialize<T>(string text);
        public string Serialize(object obj);
    }
}
