using Newtonsoft.Json;

namespace Module5HW1.Models.Request
{
    public class WorkerRequest
    {
        [JsonProperty("name")]
        public string? Name { get; set; }
        [JsonProperty("job")]
        public string? Job { get; set; }
    }
}
