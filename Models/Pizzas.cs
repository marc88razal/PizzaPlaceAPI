using System.ComponentModel;

namespace PizzaPlaceAPI.Models
{
    public class Pizzas
    {
        [DisplayName("Pizza Id")]
        public string pizza_id { get; set; }

        [DisplayName("Pizza Type Id")]
        public string pizza_type_id { get; set; }

        [DisplayName("Size")]
        public string size { get; set; }

        [DisplayName("Price")]
        public decimal? price { get; set; } 
    }
}
