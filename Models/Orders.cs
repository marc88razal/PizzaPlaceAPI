using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PizzaPlaceAPI.Models
{
    public class Orders
    {
        [DisplayName("Order Id")]
        [Key]
        public int order_id { get; set; }

        [DisplayName("Date")]
        public DateOnly date { get; set; }

        [DisplayName("Time")]
        public TimeOnly time { get; set; }
    }
}
