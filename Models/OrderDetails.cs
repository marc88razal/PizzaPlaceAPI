using System.ComponentModel;

namespace PizzaPlaceAPI.Models
{
    public class OrderDetails
    {
        [DisplayName("Order Details")]
        public int order_details { get; set; }

        [DisplayName("Order Id")]
        public int order_id { get; set; }

        [DisplayName("Pizza Id")]
        public string pizza_id { get; set; }

        [DisplayName("Quantity")]
        public int quantity { get; set; }
    }
}
