namespace Module5HW1.Models.Response
{
    public class SingleResponse<T>
    {
        public T? Data { get; set; }
        public Support? Support { get; set; }
    }
}
