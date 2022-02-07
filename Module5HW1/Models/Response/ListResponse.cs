using Newtonsoft.Json;

namespace Module5HW1.Models.Response
{
    public class ListResponse<T>
    {
        public int Page { get; set; }

        [JsonProperty("per_page")]
        public int PerPage { get; set; }
        public int Total { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }
        public List<T>? Data { get; set; }
        public Support? Support { get; set; }
    }
}
