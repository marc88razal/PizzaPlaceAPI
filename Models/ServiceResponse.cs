namespace PizzaPlaceAPI.Models
{
    public class ServiceResponse<T>
    {
        public T Data { get; set; }
        public string Code { get; set; } = "1";
        public string Status { get; set; } = "SUCCESS";
        public string Message { get; set; }
    }
}
